using Core.Application.Common.Models;

namespace Core.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;

public class DeleteLeaveRequestCommandResult(string message) : CommandResultBase(message)
{
}
