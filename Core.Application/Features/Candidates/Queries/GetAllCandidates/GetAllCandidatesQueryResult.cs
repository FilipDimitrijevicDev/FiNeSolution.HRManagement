using Core.Application.Common.Models.DTOs;

namespace Core.Application.Features.Candidates.Queries.GetAllCandidates;

public class GetAllCandidatesQueryResult
{
    public List<CandidateDto> CandidatesDto { get; set; }

    public GetAllCandidatesQueryResult(List<CandidateDto> candidatesDto)
    {
        CandidatesDto = candidatesDto;
    }
}
