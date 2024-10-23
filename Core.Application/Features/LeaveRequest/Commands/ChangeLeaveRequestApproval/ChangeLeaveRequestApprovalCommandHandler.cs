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

    public ChangeLeaveRequestApprovalCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository,
        ILeaveDistributionRepository leaveDistributionRepository,
        IMapper mapper,
        ILocalizationService localizationService)
    {
        _leaveDistributionRepository = leaveDistributionRepository;
        _mapper = mapper;
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _localizationService = localizationService;
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
            int daysRequested = GetWeekdaysCount(leaveRequest.Duration.Start, leaveRequest.Duration.End);

            var distribution = await _leaveDistributionRepository.GetUserDistributionsByLeaveTypeId(new Guid(leaveRequest.RequestingEmployeeId), leaveRequest.LeaveTypeId);
            distribution.RemainingDays -= daysRequested;

            await _leaveDistributionRepository.UpdateAsync(distribution);
        }

        return new ChangeLeaveRequestApprovalCommandResult(_localizationService.Translate(TranslationKeyConstants.LEAVEREQUEST_CHANGED_APPROVAL));
    }

    private static int GetWeekdaysCount(DateOnly start, DateOnly end)
    {
        int weekdaysCount = 0;
        for (DateOnly date = start; date <= end; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                weekdaysCount++;
            }
        }
        return weekdaysCount;
    }
}
