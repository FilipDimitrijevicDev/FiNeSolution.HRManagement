using AutoMapper;
using Core.Application.Common.Identity;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models.DTOs;
using Core.Application.Common.Models;
using Core.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Core.Application.Features.LeaveRequest.Queries.GetLeaveRequests;

public class GetLeaveRequestsQueryHandler : IRequestHandler<GetLeaveRequestsQuery, GetLeaveRequestsQueryResult>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetLeaveRequestsQueryHandler(
        ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        IUserService userService,
        IHttpContextAccessor httpContextAccessor)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<GetLeaveRequestsQueryResult> Handle(GetLeaveRequestsQuery query, CancellationToken cancellationToken)
    {
        var role = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        int pageNumber = query.PageNumber ?? 1;
        int pageSize = query.PageSize ?? 10;

        if (query.IsLoggedInUser = role == BaseConstants.RoleEmployee)
        {
            var userId = _userService.UserId;
            var leaveRequestsEmployee = await _leaveRequestRepository.GetLeaveRequestsWithDetails(
                userId,
                query.SortColumn,
                query.SortOrder,
                pageNumber,
                pageSize);

            var employee = await _userService.GetEmployee(userId);

            foreach (var leaveRequest in leaveRequestsEmployee.Items)
            {
                leaveRequest.Employee = employee;
            }

            return new GetLeaveRequestsQueryResult(leaveRequestsEmployee);
        }
        else
        {
            var employees = await _userService.GetEmployees();

            var filteredUsersIds = new List<string>();

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                filteredUsersIds = employees.Where(x =>
                    x.Firstname.Contains(query.SearchTerm) ||
                    x.Lastname.Contains(query.SearchTerm))
                    .Select(x => x.Id)
                    .ToList();

                if (filteredUsersIds.Count == 0)
                {
                    return new GetLeaveRequestsQueryResult(PagedList<LeaveRequestListDto>.Empty(pageNumber, pageSize));
                }
            }

            var leaveRequestsDto = await _leaveRequestRepository.GetLeaveRequests(
            filteredUsersIds,
            query.SortColumn,
            query.SortOrder,
            pageNumber,
            pageSize);

            foreach (var request in leaveRequestsDto.Items)
            {
                request.Employee = employees.FirstOrDefault(user => user.Id == request.RequestingEmployeeId);
            }

            return new GetLeaveRequestsQueryResult(leaveRequestsDto);
        }
    }
}
