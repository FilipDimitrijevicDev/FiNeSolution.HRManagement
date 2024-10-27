using Core.Domain;

namespace Core.Application.Common.Interfaces;

public interface ICandidateRepository : IGenericRepository<Candidate>
{
    Task<IReadOnlyCollection<Candidate>> GetFilteredAndPaginatedAsync(string? searchTerm);
}
