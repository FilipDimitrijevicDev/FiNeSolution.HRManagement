using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.Candidates.Commands.DeleteCandidate;

public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, DeleteCandidateCommandResult>
{
    private readonly ICandidateRepository _candidateRepository;    
    private readonly ILocalizationService _localizationService;
    private readonly ILogger<DeleteCandidateCommandHandler> _logger;

    public DeleteCandidateCommandHandler(
        ICandidateRepository candidateRepository,        
        ILocalizationService localizationService,
        ILogger<DeleteCandidateCommandHandler> logger)
    {
        _candidateRepository = candidateRepository;        
        _localizationService = localizationService;
        _logger = logger;
    }

    public async Task<DeleteCandidateCommandResult> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidateEntity = await _candidateRepository.GetByUidAsync(request.Uid);
        if (candidateEntity is null)
        {
            _logger.LogError("Failed to retrieve candidate");
            throw new NotFoundException(nameof(candidateEntity), request);
        }

        await _candidateRepository.DeleteAsync(candidateEntity);

        return new DeleteCandidateCommandResult(_localizationService.Translate(TranslationKeyConstants.CANDIDATE_DELETED));
    }
}
