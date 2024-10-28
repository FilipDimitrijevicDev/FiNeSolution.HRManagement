using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models;
using Core.Application.Common.Models.DTOs;
using Core.Domain;
using System.Linq.Expressions;

namespace Core.Infrastructure.Persistence.Repositories;

public class CandidateRepository : GenericRepository<Candidate>, ICandidateRepository
{
    private readonly IMapper _mapper;

    public CandidateRepository(DatabaseContext.DatabaseContext dbContext, IMapper mapper) : base(dbContext)
    {
        _mapper = mapper;
    }

    public async Task<PagedList<CandidateDto>> GetFilteredAndPaginatedAsync(
        string? searchTerm,
        string? sortColumn,
        string? sortOrder,
        int pageNumber,
        int pageSize)
    {
        IQueryable<Candidate> query = _dbContext.Candidates;

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(c =>
            c.FirstName.Contains(searchTerm) ||
            c.LastName.Contains(searchTerm)).AsQueryable();
        }

        if (sortOrder?.ToLower() == "desc")
        {
            query = query.OrderByDescending(GetSortProperty(sortColumn));
        }
        else
        {
            query = query.OrderBy(GetSortProperty(sortColumn));
        }

        return await PagedList<CandidateDto>.CreateAsync(
           query.ProjectTo<CandidateDto>(_mapper.ConfigurationProvider),
           pageNumber,
           pageSize);
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
