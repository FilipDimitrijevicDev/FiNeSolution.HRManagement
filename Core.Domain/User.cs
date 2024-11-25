using Core.Domain.Common;
using Core.Domain.Enums;

namespace Core.Domain;

public class User : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string CompanyEmail { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public required DateOnly DateOfEmployment { get; set; }
    public required StackPosition StackPosition { get; set; }
    public required Seniority Seniority { get; set; }
    public bool IsTeamLead { get; set; }
    public Guid? TeamLeadUid { get; set; }
    public Guid? DedicatedHR { get; set; }
    public DateOnly? ReligiousHolidayDay{ get; set; }
    public int? CompanyId { get; set; }
    public virtual Company Company { get; set; }
}
