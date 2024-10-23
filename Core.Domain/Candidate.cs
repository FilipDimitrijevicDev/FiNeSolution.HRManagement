using Core.Domain.Common;
using Core.Domain.Enums;

namespace Core.Domain;

public class Candidate : BaseEntity
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required StackPosition StackPosition { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public required Seniority Seniority { get; set; }
    public string? CVPath { get; set; }
    public string? Note { get; set; }
    public int? Rating { get; set; }
}