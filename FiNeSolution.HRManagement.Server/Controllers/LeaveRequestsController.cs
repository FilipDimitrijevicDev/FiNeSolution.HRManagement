using Core.Application.Features.LeaveRequest.Commands.ApproveReservedRequest;
using Core.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;
using Core.Application.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval;
using Core.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using Core.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest;
using Core.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;
using Core.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetails;
using Core.Application.Features.LeaveRequest.Queries.GetLeaveRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LeaveRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LeaveRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<GetLeaveRequestsQueryResult> Get(string? searchTerm, 
        string? sortColumn, 
        string? sortOrder, 
        int? pageNumber, 
        int? pageSize, 
        bool isLoggedInUser = false)
    {
        var leaveRequests = await _mediator.Send(new GetLeaveRequestsQuery(searchTerm, sortColumn, sortOrder, pageNumber, pageSize));
        return leaveRequests;
    }

    [HttpGet("{uid}")]
    public async Task<GetLeaveRequestDetailsQueryResult> Get(Guid uid)
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailsQuery { Uid = uid });
        return leaveRequest;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CreateLeaveRequestCommandResult>> Post(CreateLeaveRequestCommand leaveRequest)
    {
        var response = await _mediator.Send(leaveRequest);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<UpdateLeaveRequestCommandResult>> Put(UpdateLeaveRequestCommand leaveRequest)
    {
        var result = await _mediator.Send(leaveRequest);
        return Ok(result);
    }

    [HttpPut]
    [Route("CancelRequest")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<CancelLeaveRequestCommandResult>> CancelRequest(CancelLeaveRequestCommand cancelLeaveRequest)
    {
        var result = await _mediator.Send(cancelLeaveRequest);
        return Ok(result);
    }

    [HttpPut]
    [Route("UpdateApproval")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<ChangeLeaveRequestApprovalCommandResult>> UpdateApproval(ChangeLeaveRequestApprovalCommand updateApprovalRequest)
    {
        var result = await _mediator.Send(updateApprovalRequest);
        return Ok(result);
    }

    [HttpPut]
    [Route("ApproveReserved")]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<ApproveReservedRequestCommandResult>> ApproveReserved(ApproveReservedRequestCommand approveReservedCommand)
    {
        var result = await _mediator.Send(approveReservedCommand);
        return Ok(result);
    }

    [HttpDelete("{uid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<DeleteLeaveRequestCommandResult>> Delete(Guid uid)
    {
        var command = new DeleteLeaveRequestCommand { Uid = uid };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
