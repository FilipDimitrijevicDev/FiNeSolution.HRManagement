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
    public async Task<GetLeaveRequestsQueryResult> Get(bool isLoggedInUser = false)
    {
        var leaveRequests = await _mediator.Send(new GetLeaveRequestsQuery());
        return leaveRequests;
    }

    [HttpGet("{uid}")]
    public async Task<GetLeaveRequestDetailsQueryResult> Get(Guid uid)
    {
        var leaveRequest = await _mediator.Send(new GetLeaveRequestDetailsQuery { Uid = uid });
        return leaveRequest;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateLeaveRequestCommand leaveRequest)
    {
        var response = await _mediator.Send(leaveRequest);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateLeaveRequestCommand leaveRequest)
    {
        await _mediator.Send(leaveRequest);
        return NoContent();
    }

    [HttpPut]
    [Route("CancelRequest")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CancelRequest(CancelLeaveRequestCommand cancelLeaveRequest)
    {
        await _mediator.Send(cancelLeaveRequest);
        return NoContent();
    }

    [HttpPut]
    [Route("UpdateApproval")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateApproval(ChangeLeaveRequestApprovalCommand updateApprovalRequest)
    {
        await _mediator.Send(updateApprovalRequest);
        return NoContent();
    }

    [HttpDelete("{uid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid uid)
    {
        var command = new DeleteLeaveRequestCommand { Uid = uid };
        await _mediator.Send(command);
        return NoContent();
    }
}
