using Core.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(
             new ApplicationUser
             {
                 Id = "42df1250-85ef-4683-9046-6f2e5405ee3a",
                 Email = "admin@localhost.com",
                 NormalizedEmail = "ADMIN@LOCALHOST.COM",
                 UserName = "admin@localhost.com",
                 NormalizedUserName = "ADMIN@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ApplicationUser
             {
                 Id = "48a3b0de-d24d-4879-a528-ddaf38580270",
                 Email = "naissuscompanyadmin@localhost.com",
                 NormalizedEmail = "NAISSUSCOMPANYADMIN@LOCALHOST.COM",
                 UserName = "naissuscompanyadmin@localhost.com",
                 NormalizedUserName = "NAISSUSCOMPANYADMIN@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ApplicationUser
             {
                 Id = "2499bc5a-0f33-4f67-b521-5829679ee7ff",
                 Email = "filip.dimitrijevic@localhost.com",
                 NormalizedEmail = "FILIP.DIMITRIJEVIC@LOCALHOST.COM",
                 UserName = "filip.dimitrijevic@localhost.com",
                 NormalizedUserName = "FILIP.DIMITRIJEVIC@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ApplicationUser
             {
                 Id = "306627f3-c902-4d48-a6f3-d83db48df2c6",
                 Email = "hr@localhost.com",
                 NormalizedEmail = "HR@LOCALHOST.COM",
                 UserName = "hr@localhost.com",
                 NormalizedUserName = "HR@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ApplicationUser
             {
                 Id = "e19c3b4a-b3ec-49a8-9790-5d15d9b8de96",
                 Email = "marko.stoiljkovic@localhost.com",
                 NormalizedEmail = "MARKO.STOILJKOVIC@LOCALHOST.COM",
                 UserName = "marko.stoiljkovic@localhost.com",
                 NormalizedUserName = "MARKO.STOILJKOVIC@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ApplicationUser
             {
                 Id = "985fe5c1-deb8-4082-863a-840037477bc5",
                 Email = "sara.dimitrijevic@localhost.com",
                 NormalizedEmail = "SARA.DIMITRIJEVIC@LOCALHOST.COM",
                 UserName = "sara.dimitrijevic@localhost.com",
                 NormalizedUserName = "SARA.DIMITRIJEVIC@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ApplicationUser
             {
                 Id = "88ea1648-4810-4e04-81f9-cfdff02bbd22",
                 Email = "petar.markovic@localhost.com",
                 NormalizedEmail = "PETAR.MARKOVIC@LOCALHOST.COM",
                 UserName = "petar.markovic@localhost.com",
                 NormalizedUserName = "PETAR.MARKOVIC@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             }
        );
    }
}
