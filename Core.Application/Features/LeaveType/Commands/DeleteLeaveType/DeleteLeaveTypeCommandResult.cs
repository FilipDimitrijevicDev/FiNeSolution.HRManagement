using Core.Application.Common.Models;

namespace Core.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandResult(string message) : CommandResultBase(message)
{
}
