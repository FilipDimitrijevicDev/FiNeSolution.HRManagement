using MediatR;

namespace Core.Application.Features.Candidates.Queries.GetAllCandidates;

public class GetAllCandidatesQuery : IRequest<GetAllCandidatesQueryResult>
{
    public string? SearchTerm { get; set; }
    public string? SortColumn { get; set; }
    public string? SortOrder { get; set; }
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }

    public GetAllCandidatesQuery(
        string? searchTerm,
        string? sortColumn,
        string? sortOrder,
        int? pageNumber,
        int? pageSize)
    {
        SearchTerm = searchTerm;
        SortColumn = sortColumn;
        SortOrder = sortOrder;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}
