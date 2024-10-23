using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.Candidates.Commands.UpdateCandidate;

public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, UpdateCandidateCommandResult>
{
    private readonly ICandidateRepository _candidateRepository;    
    private readonly ILocalizationService _localizationService;
    private readonly ILogger<UpdateCandidateCommandHandler> _logger;

    public UpdateCandidateCommandHandler(
        ICandidateRepository candidateRepository,        
        ILocalizationService localizationService,
        ILogger<UpdateCandidateCommandHandler> logger)
    {
        _candidateRepository = candidateRepository;        
        _localizationService = localizationService;
        _logger = logger;
    }
    public async Task<UpdateCandidateCommandResult> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidateEntity = await _candidateRepository.GetByUidAsync(request.Uid);
        if (candidateEntity is null)
        {
            _logger.LogError("Failed to retrieve candidate");
            throw new NotFoundException(nameof(candidateEntity), request);
        }

        candidateEntity.FirstName = request.FirstName;
        candidateEntity.LastName = request.LastName;
        candidateEntity.Email = request.Email;
        candidateEntity.StackPosition = request.StackPosition;
        candidateEntity.Seniority = request.Seniority;
        candidateEntity.CVPath = request.CVPath;
        candidateEntity.DateOfBirth = request.DateOfBirth;
        candidateEntity.Note = request.Note;
        candidateEntity.Rating = request.Rating;
        
        await _candidateRepository.UpdateAsync(candidateEntity);

        return new UpdateCandidateCommandResult(_localizationService.Translate(TranslationKeyConstants.CANDIDATE_UPDATED));
    }
}
