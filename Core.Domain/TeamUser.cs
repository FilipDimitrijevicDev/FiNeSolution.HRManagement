using Core.Domain.Common;

namespace Core.Domain;

public class TeamUser : BaseEntity
{
    public Guid UserUid { get; set; }
    public Guid TeamUid { get; set; }
}
