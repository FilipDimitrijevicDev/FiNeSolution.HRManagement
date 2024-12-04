using Core.Application.Common.Interfaces;
using Core.Domain;
using Core.Infrastructure.Persistence.DatabaseContext;

namespace Core.Infrastructure.Persistence.Repositories;

public class TeamUserRepository : GenericRepository<TeamUser>, ITeamUserRepository
{
    public TeamUserRepository(CoreDbContext dbContext) : base(dbContext)
    {
    }
}
