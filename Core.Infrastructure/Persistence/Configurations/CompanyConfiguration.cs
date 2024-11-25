using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> modelBuilder)
    {
        modelBuilder.HasData(
            new Company
            {
                Id = 1,
                Uid = Guid.Parse("da4fdc93-facb-45e2-9170-cb94d01c42fb"),
                Name = "Naissus Tech",
                CreatedDate = DateTime.Now
            });

        modelBuilder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}
