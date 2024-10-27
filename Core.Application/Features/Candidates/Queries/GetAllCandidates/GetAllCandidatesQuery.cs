using MediatR;

namespace Core.Application.Features.Candidates.Queries.GetAllCandidates;

public class GetAllCandidatesQuery : IRequest<GetAllCandidatesQueryResult>
{
    public string? SearchTerm { get; set; }

    public GetAllCandidatesQuery(string? searchTerm)
    {
        SearchTerm = searchTerm;
    }
}
