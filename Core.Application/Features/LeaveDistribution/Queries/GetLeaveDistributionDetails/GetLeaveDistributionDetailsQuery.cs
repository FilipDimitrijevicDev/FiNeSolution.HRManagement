using MediatR;

namespace Core.Application.Features.LeaveDistribution.Queries.GetLeaveDistributionDetails;

public class GetLeaveDistributionDetailsQuery : IRequest<GetLeaveDistributionDetailsQueryResult>
{
    public string EmployeeUid { get; set; }
    public Guid LeaveTypeUid { get; set; }
}
