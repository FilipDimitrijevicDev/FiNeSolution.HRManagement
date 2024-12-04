using Core.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.Common.Models.Identity;

public class RegistrationRequest
{
    [Required]
    public required string FirstName { get; set; }

    [Required]
    public required string LastName { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MinLength(4)]
    public required string UserName { get; set; }

    [Required]
    [MinLength(6)]
    public required string Password { get; set; }

    [Required]
    public int CompanyId{ get; set; }

    public Guid TeamUid { get; set; }

    [Required]
    public DateOnly DateOfBirth { get; set; }

    [Required]
    public DateOnly DateOfEmployment { get; set; }

    [Required]
    public StackPosition StackPosition { get; set; }

    [Required]
    public Seniority Seniority { get; set; }

    public bool IsTeamLead { get; set; }
    public Guid? TeamLeadUid { get; set; }
    public Guid AssignedHRUid { get; set; }
    public DateOnly? ReligiousHolidayDay { get; set; }

    [Phone]
    public string? PhoneNumber { get; set; }

    public UserRoleEnum UserRole { get; set; }
}
