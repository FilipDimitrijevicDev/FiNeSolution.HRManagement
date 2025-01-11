using Core.Application.Common.Models;

namespace Core.Application.Features.LeaveRequest.Commands.ApproveReservedRequest;

public class ApproveReservedRequestCommandResult(string message) : CommandResultBase(message)
{
}
