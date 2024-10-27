using MediatR;

namespace Core.Application.Features.Candidates.Queries.GetAllCandidates;

public class GetAllCandidatesQuery : IRequest<GetAllCandidatesQueryResult>
{
    public string? SearchTerm { get; set; }
    public string? SortColumn { get; set; }
    public string? SortOrder { get; set; }

    public GetAllCandidatesQuery(string? searchTerm, string? sortColumn, string? sortOrder)
    {
        SearchTerm = searchTerm;
        SortColumn = sortColumn;
        SortOrder = sortOrder;
    }
}
