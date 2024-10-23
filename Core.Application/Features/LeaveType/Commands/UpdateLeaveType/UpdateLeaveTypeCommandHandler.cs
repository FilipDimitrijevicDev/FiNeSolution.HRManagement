using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, UpdateLeaveTypeCommandResult>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILocalizationService _localizationService;
    private readonly ILogger<UpdateLeaveTypeCommandHandler> _logger;

    public UpdateLeaveTypeCommandHandler(
        ILeaveTypeRepository leaveTypeRepository,
        ILocalizationService localizationService,
        ILogger<UpdateLeaveTypeCommandHandler> logger)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _localizationService = localizationService;
        _logger = logger;
    }

    public async Task<UpdateLeaveTypeCommandResult> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeEntity = await _leaveTypeRepository.GetByUidAsync(request.Uid);
        if (leaveTypeEntity == null)
        {
            _logger.LogError($"Leave Type with UID: {0} doesn't exist for Update", request.Uid);

            throw new NotFoundException(nameof(LeaveType), request.Uid);
        }

        leaveTypeEntity.Name = request.Name;
        leaveTypeEntity.DefaultDays = request.DefaultDays;
        leaveTypeEntity.RequiresHRApproval = request.RequiresHRApproval;

        await _leaveTypeRepository.UpdateAsync(leaveTypeEntity);

        return new UpdateLeaveTypeCommandResult(_localizationService.Translate(TranslationKeyConstants.LEAVETYPE_UPDATED));
    }
}
