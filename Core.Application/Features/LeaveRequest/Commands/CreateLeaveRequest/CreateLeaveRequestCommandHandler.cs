using AutoMapper;
using Core.Application.Common.Email;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Identity;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Models;
using Core.Domain.Common;
using Core.Domain.Constants;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, CreateLeaveRequestCommandResult>
{
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly ILeaveDistributionRepository _leaveDistributionRepository;
    private readonly IUserService _userService;
    private readonly IEmailSender _emailSender;
    private readonly ILocalizationService _localizationService;
    public CreateLeaveRequestCommandHandler(
        IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository, 
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveDistributionRepository leaveDistributionRepository,
        IUserService userService,
        IEmailSender emailSender,
        ILocalizationService localizationService)
    {
        _leaveDistributionRepository = leaveDistributionRepository;
        _userService = userService;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _leaveRequestRepository = leaveRequestRepository;
        _emailSender = emailSender;
        _localizationService = localizationService;
    }
    public async Task<CreateLeaveRequestCommandResult> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var employeeId = _userService.UserId;
        if (employeeId is null)
        {
            employeeId = "2499bc5a-0f33-4f67-b521-5829679ee7ff";
        }

        var distribution = await _leaveDistributionRepository.GetUserDistributionsByLeaveTypeUid(new Guid(employeeId), request.LeaveTypeUid);

        // if distributions aren't enough, return validation error with message
        if (distribution is null)
        {
            // TODO:
            throw new NotFoundException(nameof(LeaveDistribution), new Guid(employeeId));
        }

        var duration = DateRange.Create(request.StartDate, request.EndDate);

        if (duration.LengthInDays > distribution.RemainingDays)
        {
            // TODO:
            throw new BadRequestException("You do not have enough available days for this type of leave.");
        }

        var leaveRequest = new Common.Models.LeaveRequest
        {
            Uid = Guid.NewGuid(),
            Duration = duration,
            LeaveTypeId = distribution.LeaveTypeId,
            RequestComments = request.RequestComments,
            RequestStatus = Domain.Enums.RequestStatus.Pending            
        };

        var leaveRequestEntity = _mapper.Map<Domain.LeaveRequest>(leaveRequest);
        leaveRequestEntity.RequestingEmployeeId = employeeId;
        leaveRequestEntity.DateRequested = DateTime.Now;
        await _leaveRequestRepository.CreateAsync(leaveRequestEntity);

        //try
        //{
        //    var email = new EmailMessage
        //    {
        //        To = "dimitrijevicfilip995n@gmail.com",
        //        Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " +
        //            $"has been submitted successfully.",
        //        Subject = "Leave Request Submitted"
        //    };

        //    await _emailSender.SendEmail(email);
        //}
        //catch (Exception ex)
        //{
        //    throw new BadRequestException("Email service don't work as expected");
        //}

        return new CreateLeaveRequestCommandResult(_localizationService.Translate(TranslationKeyConstants.LEAVEREQUEST_CREATED));
    }
}