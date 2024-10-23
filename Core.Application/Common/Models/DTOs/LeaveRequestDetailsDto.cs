using Core.Application.Common.Models.Identity;

namespace Core.Application.Common.Models.DTOs;

public class LeaveRequestDetailsDto
{
    public Guid Uid { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string RequestingEmployeeId { get; set; }
    public Employee Employee { get; set; }
    public int LeaveTypeId { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public DateTime DateRequested { get; set; }
    public string Comments { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
}
