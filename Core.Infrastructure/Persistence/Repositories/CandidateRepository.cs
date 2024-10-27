using Core.Application.Common.Interfaces;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Infrastructure.Persistence.Repositories;

public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
{
    public CandidateRepository(DatabaseContext.DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<IReadOnlyCollection<Candidate>> GetFilteredAndPaginatedAsync(string? searchTerm, string? sortColumn, string? sortOrder)
    {
        IQueryable<Candidate> candidates = _dbContext.Candidates;

        if (sortOrder?.ToLower() == "desc")
        {
            candidates = candidates.OrderByDescending(GetSortProperty(sortColumn));
        }
        else
        {
            candidates = candidates.OrderBy(GetSortProperty(sortColumn));
        }

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            candidates = candidates.Where(c =>
            c.FirstName.Contains(searchTerm) ||
            c.LastName.Contains(searchTerm)).AsQueryable();
        }

        return await candidates.ToListAsync();
    }

    private static Expression<Func<Candidate, object>> GetSortProperty(string? sortColumn) => sortColumn?.ToLower() switch
    {
        "firstName" => candidates => candidates.FirstName,
        "lastName" => candidates => candidates.LastName,
        "stackPosition" => candidates => candidates.StackPosition,
        "dateOfBirth" => candidates => candidates.DateOfBirth,
        "seniority" => candidates => candidates.Seniority,
        "rating" => candidates => candidates.Rating,
        _ => candidates => candidates.Id
    };
}
