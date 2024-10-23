using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Application.Features.LeaveDistribution.Commands.DeleteLeaveDistribution;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.LeaveDistribution.Commands.UpdateLeaveDistribution;

public class UpdateLeaveDistributionCommandHandler : IRequestHandler<UpdateLeaveDistributionCommand, UpdateLeaveDistributionCommandResult>
{
    private readonly IMapper _mapper;
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    private readonly ILocalizationService _localizationService;
    private readonly ILogger<UpdateLeaveDistributionCommandHandler> _logger;


    public UpdateLeaveDistributionCommandHandler(
        IMapper mapper,
        ILeaveDistributionRepository leaveDistributionRepository,
        ILocalizationService localizationService,
        ILogger<UpdateLeaveDistributionCommandHandler> logger)
    {
        _leaveDistributionRepository = leaveDistributionRepository;
        _mapper = mapper;
        _localizationService = localizationService;
        _logger = logger;
    }
    public async Task<UpdateLeaveDistributionCommandResult> Handle(UpdateLeaveDistributionCommand request, CancellationToken cancellationToken)
    {
        var leaveDistributionEntity = await _leaveDistributionRepository.GetByUidAsync(request.Uid);
        if (leaveDistributionEntity == null)
        {
            _logger.LogError($"Leave Distribution with UID: {0} doesn't exist for Update", request.Uid);
            throw new NotFoundException(nameof(LeaveType), request.Uid);
        }

        leaveDistributionEntity.RemainingDays = request.RemainingDays;
        leaveDistributionEntity.LeaveType.Uid = request.LeaveTypeUId;
        leaveDistributionEntity.Period = request.Period;

        await _leaveDistributionRepository.UpdateAsync(leaveDistributionEntity);

        return new UpdateLeaveDistributionCommandResult(_localizationService.Translate(TranslationKeyConstants.UPDATE_LEAVE_DISTRIBUTION));
    }
}
