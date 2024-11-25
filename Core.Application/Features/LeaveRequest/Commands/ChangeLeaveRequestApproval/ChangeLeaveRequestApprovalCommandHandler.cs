using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Domain.Constants;
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

    public ChangeLeaveRequestApprovalCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository,
        ILeaveDistributionRepository leaveDistributionRepository,
        IMapper mapper,
        ILocalizationService localizationService,
        IWorkingDaysService workingDaysService)
    {
        _leaveDistributionRepository = leaveDistributionRepository;
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _localizationService = localizationService;
        _workingDaysService = workingDaysService;
    }
    public async Task<ChangeLeaveRequestApprovalCommandResult> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByUidAsync(request.Uid);
        if (leaveRequest is null)
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Uid);
        }

        leaveRequest.RequestStatus = request.RequestStatus;
        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        // if request is approved, get and update the employee's distributions
        if (request.RequestStatus == Domain.Enums.RequestStatus.Approved)
        {
            int workingDays = _workingDaysService.GetWorkingDaysCount(leaveRequest.Duration.Start, leaveRequest.Duration.End);

            var distribution = await _leaveDistributionRepository.GetUserDistributionsByLeaveTypeId(new Guid(leaveRequest.RequestingEmployeeId), leaveRequest.LeaveTypeId);
            distribution.RemainingDays -= workingDays;

            await _leaveDistributionRepository.UpdateAsync(distribution);
        }

        return new ChangeLeaveRequestApprovalCommandResult(_localizationService.Translate(TranslationKeyConstants.LEAVEREQUEST_CHANGED_APPROVAL));
    }
}
