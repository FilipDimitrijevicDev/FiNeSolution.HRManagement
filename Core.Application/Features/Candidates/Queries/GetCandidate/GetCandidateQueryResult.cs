using Core.Application.Common.Models.DTOs;

namespace Core.Application.Features.Candidates.Queries.GetCandidate;

public class GetCandidateQueryResult
{
    public CandidateDto CandidateDto { get; set; }

    public GetCandidateQueryResult(CandidateDto candidateDto)
    {
        CandidateDto = candidateDto;
    }
}
