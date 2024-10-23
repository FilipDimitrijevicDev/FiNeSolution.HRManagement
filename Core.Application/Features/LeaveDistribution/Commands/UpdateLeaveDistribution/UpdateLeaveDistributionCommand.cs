using MediatR;

namespace Core.Application.Features.LeaveDistribution.Commands.UpdateLeaveDistribution;

public class UpdateLeaveDistributionCommand : IRequest<UpdateLeaveDistributionCommandResult>
{
    public Guid Uid { get; set; }
    public int RemainingDays { get; set; }
    public Guid LeaveTypeUId { get; set; }
    public int Period { get; set; }
}
