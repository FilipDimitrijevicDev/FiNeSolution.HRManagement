using Core.Application.Common.Models.DTOs;

namespace Core.Application.Features.LeaveRequest.Queries.GetLeaveRequests;

public class GetLeaveRequestsQueryResult
{
    public List<LeaveRequestListDto> LeaveRequestListDto { get; set; }

    public GetLeaveRequestsQueryResult(List<LeaveRequestListDto> leaveRequestListDto)
    {
        LeaveRequestListDto = leaveRequestListDto;
    }
}
