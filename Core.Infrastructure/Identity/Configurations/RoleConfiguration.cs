using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "995d5439-2b54-458a-b08d-e0f289255a96",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new IdentityRole
            {
                Id = "ebc687e2-03df-4448-b79e-32e3e39de6bc",
                Name = "Company Administrator",
                NormalizedName = "COMPANY ADMINISTRATOR"
            },
            new IdentityRole
            {
                Id = "2ed7c2e3-d4ad-4222-9439-1700379ea772",
                Name = "HR",
                NormalizedName = "HR"
            },
            new IdentityRole
            {
                Id = "dd70f100-6753-494a-9382-1dd5ef51d4b6",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            }
        );
    }
}