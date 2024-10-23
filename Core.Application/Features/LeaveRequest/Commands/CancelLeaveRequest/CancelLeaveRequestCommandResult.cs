using Core.Application.Common.Models;

namespace Core.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;

public class CancelLeaveRequestCommandResult(string message) : CommandResultBase(message)
{
}
