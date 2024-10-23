using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Identity;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models.DTOs;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;

public class GetLeaveRequestDetailsQueryHandler : IRequestHandler<GetLeaveRequestDetailsQuery, GetLeaveRequestDetailsQueryResult>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetLeaveRequestDetailsQueryHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IUserService userService)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _userService = userService;

    }
    public async Task<GetLeaveRequestDetailsQueryResult> Handle(GetLeaveRequestDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveRequestEntity = await _leaveRequestRepository.GetLeaveRequestsWithDetails(request.Uid);
        if (leaveRequestEntity == null) 
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Uid);
        }        

        var result = _mapper.Map<List<LeaveRequestDetailsDto>>(leaveRequestEntity);

        var employee = await _userService.GetEmployee(leaveRequestEntity.First().RequestingEmployeeId);

        result.FirstOrDefault().Employee = employee;

        return new GetLeaveRequestDetailsQueryResult(result);
    }
}
