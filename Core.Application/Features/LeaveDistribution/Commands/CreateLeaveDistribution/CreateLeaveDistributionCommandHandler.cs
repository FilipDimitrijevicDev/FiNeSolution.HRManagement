﻿using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Identity;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.LeaveDistribution.Commands.CreateLeaveDistribution;

public class CreateLeaveDistributionCommandHandler : IRequestHandler<CreateLeaveDistributionCommand, CreateLeaveDistributionCommandResult>
{
    private readonly IMapper _mapper;
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IUserService _userService;
    private readonly ILocalizationService _localizationService;
    private readonly ILogger<CreateLeaveDistributionCommandHandler> _logger;

    public CreateLeaveDistributionCommandHandler(
        IMapper mapper,
        ILeaveDistributionRepository leaveDistributionRepository, 
        ILeaveTypeRepository leaveTypeRepository, 
        IUserService userService, 
        ILocalizationService localizationService,
        ILogger<CreateLeaveDistributionCommandHandler> logger)
    {
        _leaveDistributionRepository = leaveDistributionRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
        _userService = userService;
        _localizationService = localizationService;
        _logger = logger;
    }

    public async Task<CreateLeaveDistributionCommandResult> Handle(CreateLeaveDistributionCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.GetByUidAsync(request.LeaveTypeUid);
        if (leaveType == null)
        {
            _logger.LogError("Failed to retrieve leave type: {0}", request.LeaveTypeUid);
            throw new NotFoundException(nameof(LeaveType), request.LeaveTypeUid);
        }

        var employees = await _userService.GetEmployees();

        // TODO: Check for Clock service
        var period = DateTime.UtcNow.Year;

        var distribution = new List<Domain.LeaveDistribution>();
        foreach (var emp in employees)
        {
            var distributionExists = await _leaveDistributionRepository.DistributionExists(emp.Id, request.LeaveTypeUid, period);

            if (!distributionExists)
            {
                distribution.Add(new Domain.LeaveDistribution
                {
                    Uid = Guid.NewGuid(),
                    RemainingDays = leaveType.DefaultDays,
                    LeaveTypeId = leaveType.Id,                    
                    Period = period,
                    EmployeeUid = emp.Id,
                });
            }
        }

        if (distribution.Any())
        {
            await _leaveDistributionRepository.AddDistribution(distribution);
        }

        return new CreateLeaveDistributionCommandResult(_localizationService.Translate(TranslationKeyConstants.LEAVE_DISTRIBUTED));
    }
}
