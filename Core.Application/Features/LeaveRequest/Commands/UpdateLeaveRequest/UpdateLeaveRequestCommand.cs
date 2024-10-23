using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommand : IRequest<UpdateLeaveRequestCommandResult>
{
    public Guid Uid { get; set; }
    public Guid LeaveTypeUid { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Comments { get; set; }
    public bool Cancelled { get; set; }
}
