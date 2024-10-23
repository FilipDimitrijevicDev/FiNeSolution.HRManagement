using MediatR;

namespace Core.Application.Features.LeaveRequest.Queries.GetLeaveRequests;

public class GetLeaveRequestsQuery : IRequest<GetLeaveRequestsQueryResult>
{
    public bool IsLoggedInUser { get; set; }
}
