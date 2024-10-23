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
    public async Task<GetLeaveRequestsQueryResult> Handle(GetLeaveRequestsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequests = new List<Domain.LeaveRequest>();
        var requests = new List<LeaveRequestListDto>();

        var role = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        request.IsLoggedInUser = role == "Employee";  

        if (request.IsLoggedInUser)
        {
            var userId = _userService.UserId;
            leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails(userId);

            var employee = await _userService.GetEmployee(userId);
            requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
            foreach (var req in requests)
            {
                req.Employee = employee;
            }
        }
        else
        {
            leaveRequests = await _leaveRequestRepository.GetLeaveRequestsWithDetails();
            requests = _mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
            foreach (var req in requests)
            {
                req.Employee = await _userService.GetEmployee(req.RequestingEmployeeId);
            }
        }

        return new GetLeaveRequestsQueryResult(requests);
    }
}
