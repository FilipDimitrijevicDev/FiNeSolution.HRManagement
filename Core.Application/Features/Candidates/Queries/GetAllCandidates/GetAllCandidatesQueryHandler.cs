using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Application.Common.Models.DTOs;
using MediatR;

namespace Core.Application.Features.Candidates.Queries.GetAllCandidates;

public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, GetAllCandidatesQueryResult>
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetAllCandidatesQueryHandler> _logger;
    public GetAllCandidatesQueryHandler(
        ICandidateRepository candidateRepository,
        IMapper mapper,
        ILogger<GetAllCandidatesQueryHandler> logger)
    {
        _candidateRepository = candidateRepository;        
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetAllCandidatesQueryResult> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
    {
        var candidates = await _candidateRepository.GetAsync();
        if (candidates is null) 
        {
            _logger.LogError("Failed to retrieve candidates");
            throw new NotFoundException(nameof(candidates), request);
        }

        var result = _mapper.Map<List<CandidateDto>>(candidates);

        return new GetAllCandidatesQueryResult(result);
    }
}
