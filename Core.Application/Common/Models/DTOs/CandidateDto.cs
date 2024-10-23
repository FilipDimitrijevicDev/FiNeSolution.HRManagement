using Core.Domain.Enums;

namespace Core.Application.Common.Models.DTOs;

public class CandidateDto
{
    public Guid Uid { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public StackPosition StackPosition { get; set; }
    public DateOnly DateOfBirth { get; set; } 
    public Seniority Seniority { get; set; }
    public string CVPath { get; set; }
    public string Note { get; set; }
    public int Rating { get; set; }
}
