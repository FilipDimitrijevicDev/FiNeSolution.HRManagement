using Core.Application.Common.Models;

namespace Core.Application.Features.LeaveDistribution.Commands.DeleteLeaveDistribution;

public class DeleteLeaveDistributionCommandResult(string message) : CommandResultBase(message)
{
}
