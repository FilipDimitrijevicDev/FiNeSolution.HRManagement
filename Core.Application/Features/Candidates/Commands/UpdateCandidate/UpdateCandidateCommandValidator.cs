using FluentValidation;

namespace Core.Application.Features.Candidates.Commands.UpdateCandidate;

public class UpdateCandidateCommandValidator : AbstractValidator<UpdateCandidateCommand>
{
    public UpdateCandidateCommandValidator()
    {
        RuleFor(x => x.Uid)
            .NotEmpty().WithMessage("Uid cannot be empty")
            .Must(uid => Guid.TryParse(uid.ToString(), out _)).WithMessage("Invalid Uid format");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First Name cannot be empty");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last Name cannot be empty");
  
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email cannot be empty")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.StackPosition)
            .NotNull().WithMessage("Stack Position is required");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of Birth cannot be empty");

        RuleFor(x => x.Seniority)
            .NotNull().WithMessage("Seniority is required");

        RuleFor(x => x.CVPath)
            .NotEmpty().WithMessage("CV path cannot be empty");

        RuleFor(x => x.Note)
            .NotEmpty().WithMessage("Note cannot be empty");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5");
    }
}
