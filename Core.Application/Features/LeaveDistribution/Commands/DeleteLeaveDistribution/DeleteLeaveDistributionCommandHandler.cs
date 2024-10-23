using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.LeaveDistribution.Commands.DeleteLeaveDistribution;

public class DeleteLeaveDistributionCommandHandler : IRequestHandler<DeleteLeaveDistributionCommand, DeleteLeaveDistributionCommandResult>
{
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    private readonly IMapper _mapper;
    private readonly ILocalizationService _localizationService;
    private readonly ILogger<DeleteLeaveDistributionCommandHandler> _logger;

    public DeleteLeaveDistributionCommandHandler(
        ILeaveDistributionRepository leaveDistributionRepository, 
        IMapper mapper,
        ILocalizationService localizationService,
        ILogger<DeleteLeaveDistributionCommandHandler> logger)
    {
        _mapper = mapper;
        _leaveDistributionRepository = leaveDistributionRepository;
        _localizationService = localizationService;
        _logger = logger;
    }
    public async Task<DeleteLeaveDistributionCommandResult> Handle(DeleteLeaveDistributionCommand request, CancellationToken cancellationToken)
    {
        var leaveDistributionEntity = await _leaveDistributionRepository.GetByUidAsync(request.Uid);
        if (leaveDistributionEntity == null) 
        {
            _logger.LogError($"Leave Distribution with UID: {0} doesn't exist for Delete", request.Uid);
            throw new NotFoundException(nameof(LeaveDistribution), request.Uid);
        }
        
        await _leaveDistributionRepository.DeleteAsync(leaveDistributionEntity);

        return new DeleteLeaveDistributionCommandResult(_localizationService.Translate(TranslationKeyConstants.DELETE_LEAVE_DISTRIBUTION));
    }
}
