using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> modelBuilder)
    {
        modelBuilder.HasData(
             new User
             {
                 Id = 1,
                 Uid = Guid.Parse("42df1250-85ef-4683-9046-6f2e5405ee3a"),
                 CompanyEmail = "admin@localhost.com",
                 DateOfEmployment = DateOnly.MinValue,
                 DateOfBirth = DateOnly.MinValue,
                 FirstName = "System",
                 LastName = "Admin",
                 Seniority = Domain.Enums.Seniority.Unknown,
                 StackPosition = Domain.Enums.StackPosition.Unknown,
                 CreatedDate = DateTime.UtcNow,
             },
             new User
             {
                 Id = 2,
                 Uid = Guid.Parse("48a3b0de-d24d-4879-a528-ddaf38580270"),
                 CompanyEmail = "naissuscompanyadmin@localhost.com",
                 CompanyId = 1,
                 DateOfEmployment = DateOnly.MinValue,
                 DateOfBirth = DateOnly.MinValue,
                 FirstName = "Company",
                 LastName = "Admin",
                 Seniority = Domain.Enums.Seniority.Unknown,
                 StackPosition = Domain.Enums.StackPosition.Unknown,
                 CreatedDate = DateTime.UtcNow
             },
             new User
             {
                 Id = 3,
                 Uid = Guid.Parse("2499bc5a-0f33-4f67-b521-5829679ee7ff"),
                 CompanyEmail = "filip.dimitrijevic@localhost.com",
                 CompanyId = 1,
                 DateOfEmployment = new DateOnly(2021, 1, 10),
                 DateOfBirth = new DateOnly(1995, 1, 14),
                 FirstName = "Filip",
                 LastName = "Dimitrijevic",
                 Seniority = Domain.Enums.Seniority.Mid,
                 StackPosition = Domain.Enums.StackPosition.Backend,
                 CreatedDate = DateTime.UtcNow,
                 DedicatedHR = Guid.Parse("306627f3-c902-4d48-a6f3-d83db48df2c6"),
                 IsTeamLead = false,
                 TeamLeadUid = Guid.Parse("e19c3b4a-b3ec-49a8-9790-5d15d9b8de96"),
                 ReligiousHolidayDay = new DateOnly(1900, 1, 12)
             },
             new User
             {
                 Id = 4,
                 Uid = Guid.Parse("306627f3-c902-4d48-a6f3-d83db48df2c6"),
                 CompanyEmail = "hr@localhost.com",
                 CompanyId = 1,
                 DateOfEmployment = new DateOnly(2022, 1, 1),
                 DateOfBirth = new DateOnly(1990, 1, 1),
                 FirstName = "Bojana",
                 LastName = "Stoiljkovic",
                 Seniority = Domain.Enums.Seniority.Mid,
                 StackPosition = Domain.Enums.StackPosition.HR,
                 CreatedDate = DateTime.UtcNow
             },
             new User
             {
                 Id = 5,
                 Uid = Guid.Parse("e19c3b4a-b3ec-49a8-9790-5d15d9b8de96"),
                 CompanyEmail = "marko.stoiljkovic@localhost.com",
                 CompanyId = 1,
                 DateOfEmployment = new DateOnly(2015, 1, 1),
                 DateOfBirth = new DateOnly(1989, 1, 1),
                 FirstName = "Marko",
                 LastName = "Stoiljkovic",
                 Seniority = Domain.Enums.Seniority.Lead,
                 StackPosition = Domain.Enums.StackPosition.ProjectManager,
                 CreatedDate = DateTime.UtcNow,
                 DedicatedHR = Guid.Parse("306627f3-c902-4d48-a6f3-d83db48df2c6"),
                 IsTeamLead = true,
                 ReligiousHolidayDay = new DateOnly(1900, 1, 12)
             },
             new User
             {
                 Id = 6,
                 Uid = Guid.Parse("985fe5c1-deb8-4082-863a-840037477bc5"),
                 CompanyEmail = "sara.dimitrijevic@localhost.com",
                 CompanyId = 1,
                 DateOfEmployment = new DateOnly(2020, 1, 1),
                 DateOfBirth = new DateOnly(1999, 2, 12),
                 FirstName = "Sara",
                 LastName = "Dimitrijevic",
                 Seniority = Domain.Enums.Seniority.Mid,
                 StackPosition = Domain.Enums.StackPosition.ProjectManager,
                 CreatedDate = DateTime.UtcNow,
                 DedicatedHR = Guid.Parse("306627f3-c902-4d48-a6f3-d83db48df2c6"),
                 IsTeamLead = true,
                 ReligiousHolidayDay = new DateOnly(1900, 1, 12)
             },
             new User
             {
                 Id = 7,
                 Uid = Guid.Parse("88ea1648-4810-4e04-81f9-cfdff02bbd22"),
                 CompanyEmail = "petar.markovic@localhost.com",
                 CompanyId = 1,
                 DateOfEmployment = new DateOnly(2021, 1, 1),
                 DateOfBirth = new DateOnly(1998, 12, 5),
                 FirstName = "Petar",
                 LastName = "Markovic",
                 Seniority = Domain.Enums.Seniority.Senior,
                 StackPosition = Domain.Enums.StackPosition.Backend,
                 CreatedDate = DateTime.UtcNow,
                 DedicatedHR = Guid.Parse("306627f3-c902-4d48-a6f3-d83db48df2c6"),
                 IsTeamLead = false,
                 TeamLeadUid = Guid.Parse("985fe5c1-deb8-4082-863a-840037477bc5"),
                 ReligiousHolidayDay = new DateOnly(1900, 1, 12)
             });

        modelBuilder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Property (x => x.CompanyEmail)
            .IsRequired()
            .HasMaxLength(80);
    }
}
