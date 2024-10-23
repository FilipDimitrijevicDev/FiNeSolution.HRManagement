using Core.Application.Common.Models;

namespace Core.Application.Features.LeaveDistribution.Commands.CreateLeaveDistribution;

public class CreateLeaveDistributionCommandResult(string message) : CommandResultBase(message)
{
}
