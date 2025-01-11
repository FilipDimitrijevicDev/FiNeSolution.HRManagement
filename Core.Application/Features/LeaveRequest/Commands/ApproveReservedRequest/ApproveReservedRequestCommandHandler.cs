using Core.Application.Common.Exceptions;
using Core.Application.Common.Identity;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Domain.Common;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.ApproveReservedRequest;

public class ApproveReservedRequestCommandHandler : IRequestHandler<ApproveReservedRequestCommand, ApproveReservedRequestCommandResult>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    private readonly ILocalizationService _localizationService;
    private readonly IUserService _userService;
    private readonly IWorkingDaysService _workingDaysService;
    private readonly ILogger<ApproveReservedRequestCommandHandler> _logger;
    public ApproveReservedRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveDistributionRepository leaveDistributionRepository,
        ILocalizationService localizationService,
        IUserService userService,
        IWorkingDaysService workingDaysService,
        ILogger<ApproveReservedRequestCommandHandler> logger)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveDistributionRepository = leaveDistributionRepository;
        _localizationService = localizationService;
        _userService = userService;
        _workingDaysService = workingDaysService;
        _logger = logger;
    }

    public async Task<ApproveReservedRequestCommandResult> Handle(ApproveReservedRequestCommand command, CancellationToken cancellationToken)
    {
        var leaveRequest = await _leaveRequestRepository.GetByUidAsync(command.LeaveRequestUid);
        if (leaveRequest == null)
        {
            _logger.LogError("Leave request not found for approval process.");
            throw new NotFoundException(nameof(LeaveRequest), command.LeaveRequestUid);
        }

        var userUid = _userService.UserId;
        var role = _userService.Role;        

        if (leaveRequest.RequestStatus != Domain.Enums.RequestStatus.Reserved ||
            !leaveRequest.ReserveOnly || 
            userUid != leaveRequest.RequestingEmployeeId)
        {
            _logger.LogError("This request is not Reserved or does not belong to you!");
            throw new BadRequestException("This request is not Reserved or does not belong to you!");
        }

        if (command.StartDate.HasValue || command.EndDate.HasValue)
        { 
            var start = command.StartDate ?? leaveRequest.Duration.Start;
            var end = command.EndDate ?? leaveRequest.Duration.End;

            var duration = DateRange.Create(start, end);

            duration.LengthInDays = _workingDaysService.GetWorkingDaysCount(duration.Start, duration.End);

            leaveRequest.Duration = duration;            
        }

        var distribution = await _leaveDistributionRepository.GetUserDistributionsByLeaveTypeId(
                         Guid.Parse(userUid), leaveRequest.LeaveTypeId);

        if (distribution == null || distribution.RemainingDays < leaveRequest.Duration.LengthInDays)
        {
            _logger.LogError("Not enough remaining days or invalid leave distribution for the user in approval process!");
            throw new BadRequestException("Not enough remaining days or invalid leave distribution for the user.");
        }

        leaveRequest.ReserveOnly = false;
        leaveRequest.RequestStatus = Domain.Enums.RequestStatus.Pending;

        await _leaveRequestRepository.UpdateAsync(leaveRequest);

        return new ApproveReservedRequestCommandResult(_localizationService.Translate(TranslationKeyConstants.LEAVEREQUEST_CONFIRMED));
    }
}
