using Core.Application.Common.Models;

namespace Core.Application.Features.Candidates.Commands.DeleteCandidate;

public class DeleteCandidateCommandResult(string message) : CommandResultBase(message)
{
}
