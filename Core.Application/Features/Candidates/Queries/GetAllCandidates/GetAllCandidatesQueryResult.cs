using Core.Application.Common.Models;
using Core.Application.Common.Models.DTOs;

namespace Core.Application.Features.Candidates.Queries.GetAllCandidates;

public class GetAllCandidatesQueryResult
{
    public PagedList<CandidateDto> CandidatesDto { get; set; }

    public GetAllCandidatesQueryResult(PagedList<CandidateDto> candidatesDto)
    {
        CandidatesDto = candidatesDto;
    }
}
