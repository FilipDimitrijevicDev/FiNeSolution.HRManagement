using MediatR;

namespace Core.Application.Features.Candidates.Commands.DeleteCandidate;

public class DeleteCandidateCommand : IRequest<DeleteCandidateCommandResult>
{
    public Guid Uid { get; set; }

    public DeleteCandidateCommand(Guid uid)
    {
        Uid = uid;
    }
}
