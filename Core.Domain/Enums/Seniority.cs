using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Enums;

public enum Seniority
{
    [Display(Name = "Internship")]
    Intern,
    [Display(Name = "Junior Developer")]
    Junior,
    [Display(Name = "Mid-Level Developer")]
    Mid,
    [Display(Name = "Senior Developer")]
    Senior,
    [Display(Name = "Lead Developer")]
    Lead
}
