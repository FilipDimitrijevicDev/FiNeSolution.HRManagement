using AutoMapper;
using Core.Application.Common.Email;
using Core.Application.Common.Exceptions;
using Core.Application.Common.Identity;
using Core.Application.Common.Interfaces;
using Core.Application.Common.Logging;
using Core.Domain.Common;
using Core.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

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
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IWorkingDaysService _workingDaysService;
    private readonly ILogger<CreateLeaveRequestCommandHandler> _logger;

    public CreateLeaveRequestCommandHandler(
        IMapper mapper,
        ILeaveTypeRepository leaveTypeRepository,
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveDistributionRepository leaveDistributionRepository,
        IUserService userService,
        IEmailSender emailSender,
        ILocalizationService localizationService,
        IHttpContextAccessor httpContextAccessor,
        IWorkingDaysService workingDaysService,
        ILogger<CreateLeaveRequestCommandHandler> logger)
    {
        _leaveDistributionRepository = leaveDistributionRepository;
        _userService = userService;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
        _leaveRequestRepository = leaveRequestRepository;
        _emailSender = emailSender;
        _localizationService = localizationService;
        _httpContextAccessor = httpContextAccessor;
        _workingDaysService = workingDaysService;
        _logger = logger;
    }
    public async Task<CreateLeaveRequestCommandResult> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var role = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

        var employeeId = role == BaseConstants.RoleEmployee ? _userService.UserId : request.EmployeeUid.ToString();
        if (!Guid.TryParse(employeeId, out var employeeGuid))
        {
            throw new ValidationException("Invalid employee ID format.");
        }

        var distribution = await _leaveDistributionRepository.GetUserDistributionsByLeaveTypeUid(employeeGuid, request.LeaveTypeUid);

        if (distribution is null)
        {
            _logger.LogError($"Failed to found assigned leave for leaveTypeUid: {request.LeaveTypeUid} and for employeeUid: {employeeGuid}");
            throw new NotFoundException(nameof(LeaveDistribution), employeeGuid);
        }

        var duration = DateRange.Create(request.StartDate, request.EndDate);

        duration.LengthInDays = _workingDaysService.GetWorkingDaysCount(request.StartDate, request.EndDate);

        if (duration.LengthInDays > distribution.RemainingDays)
        {            
            throw new BadRequestException("You do not have enough available days for this type of leave.");
        }

        var leaveRequest = new Common.Models.LeaveRequest
        {
            Uid = Guid.NewGuid(),
            Duration = duration,
            LeaveTypeId = distribution.LeaveTypeId,
            RequestComments = request.RequestComments,
            RequestStatus = request.ReserveOnly == false ? Domain.Enums.RequestStatus.Pending : Domain.Enums.RequestStatus.Reserved,
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