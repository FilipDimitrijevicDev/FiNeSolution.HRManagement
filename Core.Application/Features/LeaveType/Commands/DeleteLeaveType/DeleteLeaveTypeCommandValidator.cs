using FluentValidation;

namespace Core.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandValidator : AbstractValidator<DeleteLeaveTypeCommand>
{
    public DeleteLeaveTypeCommandValidator()
    {
        RuleFor(x => x.Uid)
            .NotEmpty().WithMessage("Uid cannot be empty")
            .Must(uid => Guid.TryParse(uid.ToString(), out _)).WithMessage("Invalid Uid format");
    }
}
