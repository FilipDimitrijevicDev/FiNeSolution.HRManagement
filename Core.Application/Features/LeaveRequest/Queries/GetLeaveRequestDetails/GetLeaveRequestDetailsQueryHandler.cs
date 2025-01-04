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
    private readonly IUserRepository _userRepository;

    public GetLeaveRequestDetailsQueryHandler(ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        IUserService userService,
        IUserRepository userRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _userService = userService;
        _userRepository = userRepository;

    }
    public async Task<GetLeaveRequestDetailsQueryResult> Handle(GetLeaveRequestDetailsQuery query, CancellationToken cancellationToken)
    {
        var leaveRequestEntity = await _leaveRequestRepository.GetLeaveRequestsWithDetails(query.Uid);
        if (leaveRequestEntity == null) 
        {
            throw new NotFoundException(nameof(LeaveRequest), query.Uid);
        }        

        var result = _mapper.Map<List<LeaveRequestDetailsDto>>(leaveRequestEntity);

        var user = await _userRepository.GetByUidAsync(Guid.Parse(leaveRequestEntity.First().RequestingEmployeeId));

        result.FirstOrDefault().User = user;

        return new GetLeaveRequestDetailsQueryResult(result);
    }
}
