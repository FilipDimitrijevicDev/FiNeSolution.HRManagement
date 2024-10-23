using Core.Domain.Common;
using Core.Domain.Enums;

namespace Core.Domain;

public class LeaveRequest : BaseEntity
{
    public DateRange Duration { get; set; }
    public int LeaveTypeId { get; set; }
    public required LeaveType LeaveType { get; set; }
    public DateTime DateRequested { get; set; }
    public string? RequestComments { get; set; }
    public RequestStatus RequestStatus { get; set; }
    public string RequestingEmployeeId { get; set; } = string.Empty;
}
