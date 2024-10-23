using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Application.Common.Models.DTOs;
using MediatR;

namespace Core.Application.Features.Candidates.Queries.GetCandidate;

public class GetCandidateQueryHandler : IRequestHandler<GetCandidateQuery, GetCandidateQueryResult>
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetCandidateQueryHandler> _logger;
    public GetCandidateQueryHandler(ICandidateRepository candidateRepository, IMapper mapper, ILogger<GetCandidateQueryHandler> logger)
    {
        _candidateRepository = candidateRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<GetCandidateQueryResult> Handle(GetCandidateQuery request, CancellationToken cancellationToken)
    {
        var candidate = await _candidateRepository.GetByUidAsync(request.Uid);
        if (candidate is null) 
        {
            _logger.LogError("Failed to retrieve candidate");
            throw new NotFoundException(nameof(candidate), request);
        }

        var result = _mapper.Map<CandidateDto>(candidate);

        return new GetCandidateQueryResult(result);
    }
}
