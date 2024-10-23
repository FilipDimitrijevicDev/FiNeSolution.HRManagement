using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, DeleteLeaveRequestCommandResult>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILocalizationService _localizationService;
    public DeleteLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        ILocalizationService localizationService)
    {        
        _leaveRequestRepository = leaveRequestRepository;
        _localizationService = localizationService;
    }
    public async Task<DeleteLeaveRequestCommandResult> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequestEntity = await _leaveRequestRepository.GetByUidAsync(request.Uid);
        if (leaveRequestEntity == null) 
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Uid);
        }

        await _leaveRequestRepository.DeleteAsync(leaveRequestEntity);
        return new DeleteLeaveRequestCommandResult(_localizationService.Translate(TranslationKeyConstants.LEAVEREQUEST_DELETED));
    }
}
