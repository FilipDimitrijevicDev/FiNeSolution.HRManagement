using Core.Application.Common.Models;

namespace Core.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;

public class ChangeLeaveRequestApprovalCommandResult(string message) : CommandResultBase(message)
{
}
