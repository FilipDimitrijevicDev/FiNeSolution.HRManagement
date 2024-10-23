using Core.Application.Common.Interfaces;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, CreateLeaveTypeCommandResult>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILocalizationService _localizationService;

    public CreateLeaveTypeCommandHandler(
        ILeaveTypeRepository leaveTypeRepository,
        ILocalizationService localizationService)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _localizationService = localizationService;
    }
    public async Task<CreateLeaveTypeCommandResult> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = new Domain.LeaveType
        {
            Uid = Guid.NewGuid(),
            Name = request.Name,
            DefaultDays = request.DefaultDays,
            RequiresHRApproval = request.RequiresHRApproval
        };

        await _leaveTypeRepository.CreateAsync(leaveType);

        return new CreateLeaveTypeCommandResult(_localizationService.Translate(TranslationKeyConstants.LEAVETYPE_CREATED));
    }
}
