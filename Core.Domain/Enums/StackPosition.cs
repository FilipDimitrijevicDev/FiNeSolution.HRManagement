using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Enums;

public enum StackPosition
{
    [Display(Name = "Frontend Developer")]
    Frontend,
    [Display(Name = "Backend Developer")]
    Backend,
    [Display(Name = "Fullstack Developer")]
    Fullstack,
    [Display(Name = "QA Engeener")]
    QA,
    [Display(Name = "DevOps Engeener")]
    DevOps,
    [Display(Name = "DataScience Developer")]
    DataScience,
    [Display(Name = "HR")]
    HR,
    [Display(Name = "System Administrator")]
    SystemAdministrator
}
