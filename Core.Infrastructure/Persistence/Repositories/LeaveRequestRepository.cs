using Core.Application.Common.Identity;
using Core.Application.Common.Interfaces;
using Core.Domain;
using Core.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<LeaveRequest>> GetLeaveRequests(string? searchTerm)
    {
        IQueryable<LeaveRequest> requests = _dbContext.LeaveRequests.Include(x => x.LeaveType);

        var users = await _userService.GetEmployees();

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

        return requests.ToList();
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
}
