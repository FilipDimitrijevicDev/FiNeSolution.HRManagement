using AutoMapper;
using Core.Application.Common.Identity;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models.DTOs;
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

    public GetLeaveRequestsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IUserService userService, IHttpContextAccessor httpContextAccessor) 
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

        if (query.IsLoggedInUser = role == "Employee")
        {
            var userId = _userService.UserId;
            var leaveRequestsEmployee = await _leaveRequestRepository.GetLeaveRequestsWithDetails(
                userId,
                query.SortColumn,
                query.SortOrder,
                pageNumber,
                pageSize);               

            return new GetLeaveRequestsQueryResult(leaveRequestsEmployee);
        }
        else
        {
            var leaveRequestsDto = await _leaveRequestRepository.GetLeaveRequests(
                query.SearchTerm,
                query.SortColumn,
                query.SortOrder,
                pageNumber,
                pageSize);

            return new GetLeaveRequestsQueryResult(leaveRequestsDto);
        }        
    }
}
