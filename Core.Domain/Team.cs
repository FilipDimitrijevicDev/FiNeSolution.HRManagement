using Core.Domain.Common;

namespace Core.Domain;

public class Team : BaseEntity
{
    public required string Name { get; set; }
    public Guid LeadUid { get; set; }
    public int CompanyId { get; set; }
    public required Company Company { get; set; }
}
