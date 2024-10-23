using Core.Domain.Common;

namespace Core.Domain;

public class LeaveDistribution : BaseEntity
{
    public int RemainingDays { get; set; }
    public int LeaveTypeId { get; set; }
    public LeaveType LeaveType { get; set; }
    public required int Period { get; set; }
    public required string EmployeeUid { get; set; }
}
