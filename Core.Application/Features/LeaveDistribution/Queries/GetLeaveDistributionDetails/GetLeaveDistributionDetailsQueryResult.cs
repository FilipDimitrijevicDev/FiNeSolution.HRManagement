using Core.Application.Common.Models.DTOs;

namespace Core.Application.Features.LeaveDistribution.Queries.GetLeaveDistributionDetails;

public class GetLeaveDistributionDetailsQueryResult
{
    public List<LeaveDistributionDto> LeaveDistributionsDto { get; set; }

    public GetLeaveDistributionDetailsQueryResult(List<LeaveDistributionDto> leaveDistributionsDto)
    {
        LeaveDistributionsDto = leaveDistributionsDto;
    }
}
