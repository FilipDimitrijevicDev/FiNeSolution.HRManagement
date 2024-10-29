using Core.Application.Common.Models;
using Core.Application.Common.Models.DTOs;

namespace Core.Application.Features.LeaveRequest.Queries.GetLeaveRequests;

public class GetLeaveRequestsQueryResult
{
    public PagedList<LeaveRequestListDto> LeaveRequestListDto { get; set; }

    public GetLeaveRequestsQueryResult(PagedList<LeaveRequestListDto> leaveRequestListDto)
    {
        LeaveRequestListDto = leaveRequestListDto;
    }
}
