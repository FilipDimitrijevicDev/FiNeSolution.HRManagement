using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.ApproveReservedRequest;

public class ApproveReservedRequestCommand : IRequest<ApproveReservedRequestCommandResult>
{
    public Guid LeaveRequestUid { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}
