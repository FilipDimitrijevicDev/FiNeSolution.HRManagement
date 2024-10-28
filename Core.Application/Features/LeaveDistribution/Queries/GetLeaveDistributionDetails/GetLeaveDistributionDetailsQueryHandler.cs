using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models.DTOs;
using Core.Domain;
using MediatR;

namespace Core.Application.Features.LeaveDistribution.Queries.GetLeaveDistributionDetails;

public class GetLeaveDistributionDetailsQueryHandler : IRequestHandler<GetLeaveDistributionDetailsQuery, GetLeaveDistributionDetailsQueryResult>
{
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    private readonly IMapper _mapper;

    public GetLeaveDistributionDetailsQueryHandler(ILeaveDistributionRepository leaveDistributionRepository, IMapper mapper)
    {
        _leaveDistributionRepository = leaveDistributionRepository;
        _mapper = mapper;
    }

    public async Task<GetLeaveDistributionDetailsQueryResult> Handle(GetLeaveDistributionDetailsQuery query, CancellationToken cancellationToken)
    {
        var leaveDistributionEntity = await _leaveDistributionRepository.GetUserDistributionsByLeaveTypeUid(new Guid(query.EmployeeUid), query.LeaveTypeUid);
        if (leaveDistributionEntity == null) 
        {
            throw new NotFoundException("leaveDistributionEntity for {0} employee not found.", query.EmployeeUid);
        }

        var leaveDistributions = new List<Core.Domain.LeaveDistribution>
        {
            leaveDistributionEntity
        };

        var leaveDistribution = _mapper.Map<List<LeaveDistributionDto>>(leaveDistributions);

        return new GetLeaveDistributionDetailsQueryResult(leaveDistribution);
    }
}
