using Core.Domain.Enums;
using MediatR;

namespace Core.Application.Features.Candidates.Commands.UpdateCandidate;

public class UpdateCandidateCommand : IRequest<UpdateCandidateCommandResult>
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


    public UpdateCandidateCommand(Guid uid, string firstName, string lastName, string email, StackPosition stackPosition, DateOnly dateOfBirth, Seniority seniority, string cvPath, string note, int rating)
    {
        Uid = uid;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        StackPosition = stackPosition;
        DateOfBirth = dateOfBirth;
        Seniority = seniority;
        CVPath = cvPath;
        Note = note;
        Rating = rating;
    }
}
