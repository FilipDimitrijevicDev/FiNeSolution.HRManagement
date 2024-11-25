using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> modelBuilder)
    {
        modelBuilder.HasData(
            new Team
            {
                Id = 1,
                Uid = Guid.Parse("9fe876b5-0429-42e0-a205-1f6d9c2a7cb5"),
                Name = "GBI",
                CompanyId = 1,
                Company = null,
                CreatedDate = DateTime.Now,
                LeadUid = Guid.Parse("306627f3-c902-4d48-a6f3-d83db48df2c6")
            },
            new Team
            {
                Id = 2,
                Uid = Guid.Parse("bd7746a3-1385-4d0e-8fb7-3e19a0f360c1"),
                Name = "GOAT",
                CompanyId = 1,
                Company = null,
                CreatedDate = DateTime.Now,
                LeadUid = Guid.Parse("985fe5c1-deb8-4082-863a-840037477bc5")
            },
            new Team
            {
                Id = 3,
                Uid = Guid.Parse("67f55a17-fc74-4c83-ad93-e52937c2499c"),
                Name = "Support",
                CompanyId = 1,
                Company = null,
                CreatedDate = DateTime.Now,
                //LeadUid
            });

        modelBuilder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
