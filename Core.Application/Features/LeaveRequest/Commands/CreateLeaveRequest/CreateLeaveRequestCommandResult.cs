using Core.Application.Common.Models;

namespace Core.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;

public class CreateLeaveRequestCommandResult(string message) : CommandResultBase(message)
{
}
