using Core.Application.Common.Interfaces;
using Core.Domain;

namespace Core.Infrastructure.Persistence.Repositories;

public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
{
    public CandidateRepository(DatabaseContext.DatabaseContext dbContext) : base(dbContext)
    {
    }
}
