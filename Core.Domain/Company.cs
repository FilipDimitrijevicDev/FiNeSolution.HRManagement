using Core.Domain.Common;

namespace Core.Domain;

public class Company : BaseEntity
{
    public required string Name { get; set; }
    public virtual ICollection<User> Users { get; set; } = new List<User>();
    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
}
