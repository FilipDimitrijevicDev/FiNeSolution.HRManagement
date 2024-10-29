using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Application.Common.Identity;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models;
using Core.Application.Common.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Infrastructure.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<Domain.LeaveRequest>, ILeaveRequestRepository
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public LeaveRequestRepository(DatabaseContext.DatabaseContext dbContext, IUserService userService, IMapper mapper) : base(dbContext)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<PagedList<LeaveRequestListDto>> GetLeaveRequests(
        string? searchTerm,
        string? sortColumn,
        string? sortOrder,
        int pageNumber,
        int pageSize)
    {
        IQueryable<Domain.LeaveRequest> query = _dbContext.LeaveRequests.Include(x => x.LeaveType);

        var employees = await _userService.GetEmployees();

        query = SortAndOrder(sortColumn, sortOrder, query);

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var filteredUsersIds = employees.Where(x =>
                x.Firstname.Contains(searchTerm) ||
                x.Lastname.Contains(searchTerm))
                .Select(x => x.Id)
                .ToList();

            if (filteredUsersIds.Count == 0)
            {
                return null;
            }

            query = query.Where(lr => filteredUsersIds.Contains(lr.RequestingEmployeeId));
        }

        var result = await PagedList<LeaveRequestListDto>.CreateAsync(
            query.ProjectTo<LeaveRequestListDto>(_mapper.ConfigurationProvider),
            pageNumber,
            pageSize);

        foreach (var request in result.Items)
        {
            request.Employee = employees.FirstOrDefault(user => user.Id == request.RequestingEmployeeId);
        }

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

        var employee = await _userService.GetEmployee(uid);

        foreach (var request in result.Items)
        {
            request.Employee = employee;
        }

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
