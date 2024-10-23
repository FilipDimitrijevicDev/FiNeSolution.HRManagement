using MediatR;

namespace Core.Application.Features.Candidates.Queries.GetCandidate;

public class GetCandidateQuery : IRequest<GetCandidateQueryResult>
{
    public Guid Uid { get; set; }

    public GetCandidateQuery(Guid uid)
    {
        Uid = uid;
    }
}
