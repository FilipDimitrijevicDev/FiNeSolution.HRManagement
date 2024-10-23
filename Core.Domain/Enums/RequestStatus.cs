
namespace Core.Domain.Enums;

public enum RequestStatus
{
    Cancelled = 0,
    Reserved = 1,
    Pending = 2,
    Approved = 3,
    HalfApproved = 4,
    Rejected = 5
}
