using Core.Application.Common.Models;

namespace Core.Application.Features.Candidates.Commands.UpdateCandidate;

public class UpdateCandidateCommandResult(string message) : CommandResultBase(message)
{
}
