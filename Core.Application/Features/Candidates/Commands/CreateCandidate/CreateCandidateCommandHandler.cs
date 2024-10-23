using Core.Application.Common.Interfaces;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.Candidates.Commands.CreateCandidate;

public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, CreateCandidateCommandResult>
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly ILocalizationService _localizationService;
    public CreateCandidateCommandHandler(
        ICandidateRepository candidateRepository,
        ILocalizationService localizationService)
    {
        _candidateRepository = candidateRepository;
        _localizationService = localizationService;
    }

    public async Task<CreateCandidateCommandResult> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidate = new Domain.Candidate
        {
            Uid = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth,
            Email = request.Email,
            StackPosition = request.StackPosition,
            Seniority = request.Seniority,
            Rating = request.Rating,
            CVPath = request.CVPath,
            Note = request.Note,
        };

        await _candidateRepository.CreateAsync(candidate);

        return new CreateCandidateCommandResult(_localizationService.Translate(TranslationKeyConstants.CANDIDATE_ADDED));
    }
}
