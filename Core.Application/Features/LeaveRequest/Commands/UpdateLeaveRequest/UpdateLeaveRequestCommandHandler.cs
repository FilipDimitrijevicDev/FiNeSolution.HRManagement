using AutoMapper;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Interfaces;
using Core.Domain.Common;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, UpdateLeaveRequestCommandResult>
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly ILocalizationService _localizationService;
    public UpdateLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        IMapper mapper,
        ILocalizationService localizationService)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _localizationService = localizationService;
    }
    public async Task<UpdateLeaveRequestCommandResult> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequestEntity = await _leaveRequestRepository.GetByUidAsync(request.Uid);
        if (leaveRequestEntity == null) 
        {
            throw new NotFoundException(nameof(LeaveRequest), request.Uid);
        }

        var leaveRequest = _mapper.Map<Common.Models.LeaveRequest>(leaveRequestEntity);

        var duration = DateRange.Create(request.StartDate, request.EndDate);

        leaveRequest.RequestComments = request.Comments;
        leaveRequest.Duration = duration;
        leaveRequest.LeaveType.Uid = request.LeaveTypeUid;

        var result = _mapper.Map<Domain.LeaveRequest>(leaveRequest);

        await _leaveRequestRepository.UpdateAsync(result);

        return new UpdateLeaveRequestCommandResult(_localizationService.Translate(TranslationKeyConstants.LEAVEREQUEST_UPDATED));
    }
}