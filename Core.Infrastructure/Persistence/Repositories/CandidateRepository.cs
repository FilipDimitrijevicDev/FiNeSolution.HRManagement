using Core.Application.Common.Interfaces;
using Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure.Persistence.Repositories;

public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
{
    public CandidateRepository(DatabaseContext.DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyCollection<Candidate>> GetFilteredAndPaginatedAsync(string? searchTerm)
    {
        IQueryable<Candidate> candidates = _dbContext.Candidates;

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            candidates = candidates.Where(c =>
            c.FirstName.Contains(searchTerm) ||
            c.LastName.Contains(searchTerm)).AsQueryable();
        }

        return await candidates.ToListAsync();
    }
}
