using Core.Application.Common.Models.Identity;
using Core.Domain;
using Core.Domain.Enums;

namespace Core.Application.Common.Models.DTOs;

public class LeaveRequestListDto
{
    public Guid Uid { get; set; }
    public int Id { get; set; }
    public Guid RequestingEmployeeId { get; set; }
    public User User { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime DateRequested { get; set; }
    public RequestStatus RequestStatus{ get; set; }
}
