using Core.Application.Common.Identity;
using Core.Application.Common.Interfaces;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.Infrastructure.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly IUserService _userService;

    public LeaveRequestRepository(DatabaseContext.DatabaseContext dbContext, IUserService userService) : base(dbContext)
    {
        _userService = userService;
    }

    public async Task<LeaveRequest> GetLeaveRequestByUid(Guid uid)
    {
        var result = await _dbContext.LeaveRequests
            .Include(x => x.LeaveType)
            .SingleOrDefaultAsync(x => x.Uid == uid);

        return result;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequests(string? searchTerm, string? sortColumn, string? sortOrder, int pageNumber, int pageSize)
    {
        IQueryable<LeaveRequest> requests = _dbContext.LeaveRequests.Include(x => x.LeaveType);

        var users = await _userService.GetEmployees();

        if (sortOrder?.ToLower() == "desc")
        {
            requests = requests.OrderByDescending(GetSortProperty(sortColumn));
        }
        else
        {
            requests = requests.OrderBy(GetSortProperty(sortColumn));
        }

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var filteredUsers = users.Where(x =>
                x.Firstname.Contains(searchTerm) ||
                x.Lastname.Contains(searchTerm));

            if (filteredUsers.Count() == 0)
            {
                return null;
            }

            foreach (var fusers in filteredUsers)
            {
                requests = requests.Where(x => x.RequestingEmployeeId == fusers.Id).AsQueryable();
            }
        }

        var result = requests.Skip(pageNumber * pageSize).Take(pageSize).ToListAsync();

        return await result;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(Guid uid)
    {
        var result = await _dbContext.LeaveRequests
            .Where(x => x.Uid == uid)
            .Include(x => x.LeaveType)
            .ToListAsync();

        return result;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string uid)
    {
        var result = await _dbContext.LeaveRequests
            .Where(x => x.RequestingEmployeeId == uid)
            .Include(x => x.LeaveType)
            .ToListAsync();

        return result;
    }

    private static Expression<Func<LeaveRequest, object>> GetSortProperty(string? sortColumn) => sortColumn?.ToLower() switch
    {
        "startDate" => leaverequest => leaverequest.Duration.Start,
        "endDate" => leaverequest => leaverequest.Duration.End,
        "requestStatus" => leaverequest => leaverequest.RequestStatus,
        "leaveType" => leaverequst => leaverequst.LeaveTypeId,
        _ => leaverequest => leaverequest.Id
    };
}
