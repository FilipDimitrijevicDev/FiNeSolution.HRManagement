using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, DeleteLeaveTypeCommandResult>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILocalizationService _localizationService;
    private readonly ILogger<DeleteLeaveTypeCommandHandler> _logger;

    public DeleteLeaveTypeCommandHandler(
        ILeaveTypeRepository leaveTypeRepository,
        ILocalizationService localizationService,
        ILogger<DeleteLeaveTypeCommandHandler> logger)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _localizationService = localizationService;
        _logger = logger;
    }

    public async Task<DeleteLeaveTypeCommandResult> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeToDelete = await _leaveTypeRepository.GetByUidAsync(request.Uid);
        if (leaveTypeToDelete == null)
        {
            _logger.LogError($"Leave Type with UID: {0} doesn't exist for Delete", request.Uid);
            throw new NotFoundException(nameof(LeaveType), request.Uid);
        }

        await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

        return new DeleteLeaveTypeCommandResult(_localizationService.Translate(TranslationKeyConstants.LEAVETYPE_DELETED));
    }
}
