using Core.Application.Common.Models;

namespace Core.Application.Features.Candidates.Commands.CreateCandidate;

public class CreateCandidateCommandResult(string message) : CommandResultBase(message)
{
}
