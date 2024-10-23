using Core.Domain.Enums;
using MediatR;

namespace Core.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommand : IRequest<ChangeLeaveRequestApprovalCommandResult>
{
    public Guid Uid { get; set; }

    public RequestStatus RequestStatus { get; set; }
}
