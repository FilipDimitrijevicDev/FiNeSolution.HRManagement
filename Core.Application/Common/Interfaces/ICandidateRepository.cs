using Core.Application.Common.Models;
using Core.Application.Common.Models.DTOs;
using Core.Domain;

namespace Core.Application.Common.Interfaces;

public interface ICandidateRepository : IGenericRepository<Candidate>
{
    Task<PagedList<CandidateDto>> GetFilteredAndPaginatedAsync(
        string? searchTerm,
        string? sortColumn,
        string? sortOrder,
        int pageNumber,
        int pageSize);
}
