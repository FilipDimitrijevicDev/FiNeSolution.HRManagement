﻿using System.ComponentModel.DataAnnotations;

namespace Core.Application.Common.Models.Identity;

public class RegistrationRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(4)]
    public string UserName { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    public string CompanyName { get; set; }

    public DateOnly DateOfBirth { get; set; }
}
