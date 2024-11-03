using Core.Application.Common.Models;
using Core.Application.Common.Models.DTOs;

namespace Core.Application.Common.Interfaces;

public interface ILeaveRequestRepository : IGenericRepository<Domain.LeaveRequest>
{
    Task<PagedList<LeaveRequestListDto>> GetLeaveRequests(List<string> filteredUsersIds, string? sortColumn, string? sortOrder, int pageNumber, int pageSize);
    Task<List<Domain.LeaveRequest>> GetLeaveRequestsWithDetails(Guid uid);
    Task<PagedList<LeaveRequestListDto>> GetLeaveRequestsWithDetails(string userUid, string? sortColumn, string? sortOrder, int pageNumber, int pageSize);
}
