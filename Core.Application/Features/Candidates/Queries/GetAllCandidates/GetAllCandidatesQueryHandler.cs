using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Application.Common.Models;
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

    public async Task<GetAllCandidatesQueryResult> Handle(GetAllCandidatesQuery query, CancellationToken cancellationToken)
    {
        var pageNumber = 1;
        var pageSize = 10;
        if (query.PageNumber.HasValue && query.PageSize.HasValue)
        {
            pageNumber = query.PageNumber.Value;
            pageSize = query.PageSize.Value;
        }
        var candidates = await _candidateRepository.GetFilteredAndPaginatedAsync(
            query.SearchTerm,
            query.SortColumn,
            query.SortOrder,
            pageNumber,
            pageSize);

        if (candidates is null) 
        {
            _logger.LogError("Failed to retrieve candidates");
            throw new NotFoundException(nameof(candidates), query);
        }

        return new GetAllCandidatesQueryResult(candidates);
    }
}
