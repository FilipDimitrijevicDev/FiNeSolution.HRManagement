using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models;
using Core.Application.Common.Models.DTOs;
using Core.Infrastructure.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Infrastructure.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<Domain.LeaveRequest>, ILeaveRequestRepository
{
    private readonly IMapper _mapper;

    public LeaveRequestRepository(CoreDbContext dbContext, IMapper mapper) : base(dbContext)
    {
        _mapper = mapper;
    }

    public async Task<PagedList<LeaveRequestListDto>> GetLeaveRequests(
        List<Guid> filteredUserUids,
        string? sortColumn,
        string? sortOrder,
        int pageNumber,
        int pageSize)
    {
        IQueryable<Domain.LeaveRequest> query = _dbContext.LeaveRequests.Include(x => x.LeaveType);

        query = SortAndOrder(sortColumn, sortOrder, query);

        if (filteredUserUids != null && filteredUserUids.Count != 0)
        {
            var stringUserIds = filteredUserUids.Select(id => id.ToString()).ToList();
            query = query.Where(lr => stringUserIds.Contains(lr.RequestingEmployeeId));
        }

        var result = await PagedList<LeaveRequestListDto>.CreateAsync(
            query.ProjectTo<LeaveRequestListDto>(_mapper.ConfigurationProvider),
            pageNumber,
            pageSize);

        return result;
    }

    public async Task<PagedList<LeaveRequestListDto>> GetLeaveRequestsWithDetails(
        string uid,
        string? sortColumn,
        string? sortOrder,
        int pageNumber,
        int pageSize)
    {
        IQueryable<Domain.LeaveRequest> query = _dbContext.LeaveRequests
            .Where(x => x.RequestingEmployeeId == uid)
            .Include(x => x.LeaveType);

        query = SortAndOrder(sortColumn, sortOrder, query);

        var result = await PagedList<LeaveRequestListDto>.CreateAsync(
            query.ProjectTo<LeaveRequestListDto>(_mapper.ConfigurationProvider),
            pageNumber, pageSize);

        return result;
    }
    public async Task<List<Domain.LeaveRequest>> GetLeaveRequestsWithDetails(Guid uid)
    {
        var result = await _dbContext.LeaveRequests
            .Where(x => x.Uid == uid)
            .Include(x => x.LeaveType)
            .ToListAsync();

        return result;
    }
    private static IQueryable<Domain.LeaveRequest> SortAndOrder(string? sortColumn, string? sortOrder, IQueryable<Domain.LeaveRequest> query)
    {
        if (sortOrder?.ToLower() == "desc")
        {
            query = query.OrderByDescending(GetSortProperty(sortColumn));
        }
        else
        {
            query = query.OrderBy(GetSortProperty(sortColumn));
        }

        return query;
    }
    private static Expression<Func<Domain.LeaveRequest, object>> GetSortProperty(string? sortColumn) => sortColumn?.ToLower() switch
    {
        "startDate" => leaverequest => leaverequest.Duration.Start,
        "endDate" => leaverequest => leaverequest.Duration.End,
        "requestStatus" => leaverequest => leaverequest.RequestStatus,
        "leaveType" => leaverequst => leaverequst.LeaveTypeId,
        _ => leaverequest => leaverequest.Id
    };
}
