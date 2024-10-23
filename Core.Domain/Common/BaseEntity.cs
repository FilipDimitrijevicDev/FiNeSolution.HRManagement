namespace Core.Domain.Common;

public abstract class BaseEntity : IAffectedDateTimes
{
    public int Id { get; set; }
    public Guid Uid { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
