using FluentValidation;

namespace Core.Application.Features.Candidates.Commands.DeleteCandidate;

public class DeleteCandidateCommandValidator : AbstractValidator<DeleteCandidateCommand>
{
    public DeleteCandidateCommandValidator()
    {
        RuleFor(x => x.Uid)
            .NotEmpty().WithMessage("Uid cannot be empty")
            .Must(uid => Guid.TryParse(uid.ToString(), out _)).WithMessage("Invalid Uid format");
    }
}
