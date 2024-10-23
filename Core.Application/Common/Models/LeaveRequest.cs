using Core.Application.Common.Models.DTOs;
using Core.Domain.Common;
using Core.Domain.Enums;

namespace Core.Application.Common.Models;

public class LeaveRequest
{
    public Guid Uid { get; set; }
    public DateRange Duration { get; set; }
    public Guid RequestingEmployeeUid { get; set; }
    public int LeaveTypeId { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; }
    public RequestStatus RequestStatus { get; set; }
}
