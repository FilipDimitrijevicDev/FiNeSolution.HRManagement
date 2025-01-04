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
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetLeaveRequestsQueryHandler(
        ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        IUserService userService,
        IUserRepository userRepository,
        IHttpContextAccessor httpContextAccessor)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _userService = userService;
        _userRepository = userRepository;
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

            var user = await _userRepository.GetByUidAsync(Guid.Parse(userId));

            foreach (var leaveRequest in leaveRequestsEmployee.Items)
            {
                leaveRequest.User = user;
            }

            return new GetLeaveRequestsQueryResult(leaveRequestsEmployee);
        }
        else
        {
            var users = await _userRepository.GetAsync();

            var userDictionary = users.ToDictionary(user => user.Uid, user => user);

            var filteredUserUids = new List<Guid>();

            if (!string.IsNullOrWhiteSpace(query.SearchTerm))
            {
                filteredUserUids = users.Where(x =>
                    x.FirstName.Contains(query.SearchTerm) ||
                    x.LastName.Contains(query.SearchTerm))
                    .Select(x => x.Uid)
                    .ToList();

                if (filteredUserUids.Count == 0)
                {
                    return new GetLeaveRequestsQueryResult(PagedList<LeaveRequestListDto>.Empty(pageNumber, pageSize));
                }
            }

            var leaveRequestsDto = await _leaveRequestRepository.GetLeaveRequests(
            filteredUserUids,
            query.SortColumn,
            query.SortOrder,
            pageNumber,
            pageSize);

            foreach (var request in leaveRequestsDto.Items)
            {
                // Check if the UserUid exists in the dictionary and assign the User entity
                if (userDictionary.TryGetValue(request.RequestingEmployeeId, out var user))
                {
                    request.User = user;
                }
                else
                {
                    request.User = null;  // TODO: Handle if the User is not found
                }
            }

            return new GetLeaveRequestsQueryResult(leaveRequestsDto);
        }
    }
}
