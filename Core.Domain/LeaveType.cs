using Core.Domain.Common;

namespace Core.Domain
{
    public class LeaveType : BaseEntity
    {
        public required string Name { get; set; } = string.Empty;
        public required int DefaultDays { get; set; }
        public required bool RequiresHRApproval { get; set; }
    }
}