using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommand : IRequest<CreateLeaveRequestCommandResult>
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public Guid LeaveTypeUid { get; set; }
    public string RequestComments { get; set; } = string.Empty;
}
