using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;

public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, CancelLeaveRequestCommandResult>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    private readonly ILocalizationService _localizationService;
    public CancelLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveDistributionRepository leaveDistributionRepository,
        ILocalizationService localizationService)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveDistributionRepository = leaveDistributionRepository;
        _localizationService = localizationService;
    }
    public async Task<CancelLeaveRequestCommandResult> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequestEntity = await _leaveRequestRepository.GetByUidAsync(request.Uid);
        if (leaveRequestEntity == null) 
        {
            // TODO:
            throw new NotFoundException(nameof(LeaveRequest), request.Uid);
        }

        leaveRequestEntity.RequestStatus = Domain.Enums.RequestStatus.Cancelled;
        
        await _leaveRequestRepository.UpdateAsync(leaveRequestEntity);

        if (leaveRequestEntity.RequestStatus == Domain.Enums.RequestStatus.Approved)
        {
            int daysRequested = leaveRequestEntity.Duration.LengthInDays;
            var distribution = await _leaveDistributionRepository.GetUserDistributionsByLeaveTypeId
                                              (new Guid(leaveRequestEntity.RequestingEmployeeId), leaveRequestEntity.LeaveTypeId);
            if (distribution == null)
            {
                // TODO:
            }

            distribution.RemainingDays += daysRequested;

            await _leaveDistributionRepository.UpdateAsync(distribution);
        }

        return new CancelLeaveRequestCommandResult(_localizationService.Translate(TranslationKeyConstants.LEAVEREQUEST_CANCELED));
    }
}
