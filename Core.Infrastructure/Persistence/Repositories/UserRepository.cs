using Core.Application.Common.Interfaces;
using Core.Domain;
using Core.Infrastructure.Persistence.DatabaseContext;

namespace Core.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(CoreDbContext dbContext) : base(dbContext)
    {
    }
}
