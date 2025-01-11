using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Identity;
using Core.Application.Common.Interfaces;
using Core.Domain;
using Core.Domain.Constants;
using Core.Domain.Enums;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, ChangeLeaveRequestApprovalCommandResult>
{
    private readonly IMapper _mapper;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IWorkingDaysService _workingDaysService;
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;

    public ChangeLeaveRequestApprovalCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository,
        ILeaveDistributionRepository leaveDistributionRepository,
        IMapper mapper,
        ILocalizationService localizationService,
        IWorkingDaysService workingDaysService,
        IUserRepository userRepository,
        IUserService userService)
    {
        _leaveDistributionRepository = leaveDistributionRepository;
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _localizationService = localizationService;
        _workingDaysService = workingDaysService;
        _userRepository = userRepository;
        _userService = userService;
    }
    public async Task<ChangeLeaveRequestApprovalCommandResult> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByUidAsync(request.Uid);
        if (leaveRequest is null)
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Uid);
        }

        // Get User from LR and check if is TL
        var user = await _userRepository.GetByUidAsync(Guid.Parse(leaveRequest.RequestingEmployeeId));
        if (user is null)
        {
            throw new NotFoundException(nameof(user), leaveRequest.RequestingEmployeeId);
        }

        ProcessLeaveRequestApproval(request, leaveRequest, user);

        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        // if request is approved, get and update the employee's distributions
        if (leaveRequest.RequestStatus == RequestStatus.Approved)
        {
            int workingDays = _workingDaysService.GetWorkingDaysCount(leaveRequest.Duration.Start, leaveRequest.Duration.End);

            var distribution = await _leaveDistributionRepository.GetUserDistributionsByLeaveTypeId(
                    new Guid(leaveRequest.RequestingEmployeeId),
                    leaveRequest.LeaveTypeId);

            distribution.RemainingDays -= workingDays;

            await _leaveDistributionRepository.UpdateAsync(distribution);
        }

        return new ChangeLeaveRequestApprovalCommandResult(_localizationService.Translate(TranslationKeyConstants.LEAVEREQUEST_CHANGED_APPROVAL));
    }

    private void ProcessLeaveRequestApproval(ChangeLeaveRequestApprovalCommand request, Domain.LeaveRequest? leaveRequest, User? user)
    {
        var role = _userService.Role;

        if (leaveRequest == null || user == null || string.IsNullOrEmpty(role))
        {
            throw new ArgumentNullException("Invalid input parameters");
        }

        bool isRequestApproved = request.RequestStatus == RequestStatus.Approved;
        bool isRequestNotRejected = leaveRequest.RequestStatus != RequestStatus.Rejected;
        bool isPending = leaveRequest.RequestStatus == RequestStatus.Pending;
        bool isHR = role == BaseConstants.RoleHR || role == BaseConstants.RoleCompanyAdmin;
        bool isEmployee = role == BaseConstants.RoleEmployee;
        bool isTeamLeadAssigned = user.TeamLeadUid == Guid.Parse(_userService.UserId);

        if (user.IsTeamLead && isHR)
        {
            leaveRequest.RequestStatus = request.RequestStatus;
            return;
        }

        if (isRequestNotRejected)
        {
            if (isHR)
            {
                leaveRequest.RequestStatus = isRequestApproved && isPending
                    ? RequestStatus.HalfApproved
                    : request.RequestStatus;
            }
            else if (isEmployee && isTeamLeadAssigned)
            {
                leaveRequest.RequestStatus = isRequestApproved && isPending
                    ? RequestStatus.HalfApproved
                    : request.RequestStatus;
            }
        }
    }
}
