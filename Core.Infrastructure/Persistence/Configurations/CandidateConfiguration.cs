using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations;

public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
{
    public void Configure(EntityTypeBuilder<Candidate> modelBuilder)
    {
        modelBuilder.HasData(
               new Candidate
               {
                   Id = 1,
                   Uid = Guid.NewGuid(),
                   FirstName = "John",
                   LastName = "Doe",
                   Email = "john.doe@example.com",
                   StackPosition = Domain.Enums.StackPosition.Backend,
                   DateOfBirth = new DateOnly(1990, 5, 15),
                   Seniority = Domain.Enums.Seniority.Senior,
                   CVPath = "/uploads/john_doe_cv.pdf",
                   Note = "Candidate shows strong skills in backend development.",
                   Rating = 4
               },
               new Candidate
               {
                   Id = 2,
                   Uid = Guid.NewGuid(),
                   FirstName = "Alice",
                   LastName = "Smith",
                   Email = "alice.smith@example.com",
                   StackPosition = Domain.Enums.StackPosition.Fullstack,
                   DateOfBirth = new DateOnly(1985, 12, 30),
                   Seniority = Domain.Enums.Seniority.Senior,
                   CVPath = "/uploads/alice_smith_cv.pdf",
                   Note = "Experienced project manager with a strong background in Agile methodologies.",
                   Rating = 5
               },
               new Candidate
               {
                   Id = 3,
                   Uid = Guid.NewGuid(),
                   FirstName = "Michael",
                   LastName = "Johnson",
                   Email = "michael.johnson@example.com",
                   StackPosition = 0,
                   DateOfBirth = new DateOnly(1992, 4, 10),
                   Seniority = Domain.Enums.Seniority.Junior,
                   CVPath = "/uploads/michael_johnson_cv.pdf",
                   Note = "Front-end developer with expertise in React and Vue.js.",
                   Rating = 3
               },
               new Candidate
               {
                   Id = 4,
                   Uid = Guid.NewGuid(),
                   FirstName = "Emma",
                   LastName = "Williams",
                   Email = "emma.williams@example.com",
                   StackPosition = Domain.Enums.StackPosition.Fullstack,
                   DateOfBirth = new DateOnly(1988, 8, 25),
                   Seniority = Domain.Enums.Seniority.Junior,
                   CVPath = "/uploads/emma_williams_cv.pdf",
                   Note = "Full-stack developer with strong skills in Node.js and .NET Core.",
                   Rating = 4
               },
               new Candidate
               {
                   Id = 5,
                   Uid = Guid.NewGuid(),
                   FirstName = "David",
                   LastName = "Brown",
                   Email = "david.brown@example.com",
                   StackPosition = Domain.Enums.StackPosition.DevOps,
                   DateOfBirth = new DateOnly(1995, 11, 15),
                   Seniority = Domain.Enums.Seniority.Mid,
                   CVPath = "/uploads/david_brown_cv.pdf",
                   Note = "DevOps engineer with experience in CI/CD pipelines and containerization.",
                   Rating = 5
               }
           );
    }
}
