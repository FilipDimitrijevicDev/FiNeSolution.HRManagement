using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Infrastructure.Persistence.Configurations;

class TeamUserConfiguration : IEntityTypeConfiguration<TeamUser>
{
    public void Configure(EntityTypeBuilder<TeamUser> modelBuilder)
    {
        modelBuilder.HasData(
             new TeamUser
             {
                 Id = 1,
                 Uid = Guid.NewGuid(),
                 TeamUid = Guid.Parse("9fe876b5-0429-42e0-a205-1f6d9c2a7cb5"),
                 UserUid = Guid.Parse("2499bc5a-0f33-4f67-b521-5829679ee7ff")  
             },
             new TeamUser
             {
                 Id = 2,
                 Uid = Guid.NewGuid(),
                 TeamUid = Guid.Parse("9fe876b5-0429-42e0-a205-1f6d9c2a7cb5"),
                 UserUid = Guid.Parse("e19c3b4a-b3ec-49a8-9790-5d15d9b8de96") 
             },
             new TeamUser
             {
                 Id = 3,
                 Uid = Guid.NewGuid(),
                 TeamUid = Guid.Parse("67f55a17-fc74-4c83-ad93-e52937c2499c"), 
                 UserUid = Guid.Parse("306627f3-c902-4d48-a6f3-d83db48df2c6") 
             },
             new TeamUser
             {
                 Id = 4,
                 Uid = Guid.NewGuid(),
                 TeamUid = Guid.Parse("bd7746a3-1385-4d0e-8fb7-3e19a0f360c1"), 
                 UserUid = Guid.Parse("985fe5c1-deb8-4082-863a-840037477bc5") 
             },
             new TeamUser
             {
                 Id = 5,
                 Uid = Guid.NewGuid(),
                 TeamUid = Guid.Parse("bd7746a3-1385-4d0e-8fb7-3e19a0f360c1"),
                 UserUid = Guid.Parse("88ea1648-4810-4e04-81f9-cfdff02bbd22") 
             });
    }
}
