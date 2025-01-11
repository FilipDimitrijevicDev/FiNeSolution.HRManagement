using FluentValidation;

namespace Core.Application.Features.LeaveRequest.Commands.ApproveReservedRequest;

public class ApproveReservedRequestCommandValidator : AbstractValidator<ApproveReservedRequestCommand>
{
    public ApproveReservedRequestCommandValidator()
    {
        RuleFor(x => x.LeaveRequestUid)
            .NotEmpty()
            .NotNull();
    }
}
