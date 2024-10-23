using Core.Application.Features.Candidates.Commands.CreateCandidate;
using Core.Application.Features.Candidates.Commands.DeleteCandidate;
using Core.Application.Features.Candidates.Commands.UpdateCandidate;
using Core.Application.Features.Candidates.Queries.GetAllCandidates;
using Core.Application.Features.Candidates.Queries.GetCandidate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CandidatesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CandidatesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<GetAllCandidatesQueryResult> GetAllLeaveTypes()
    {
        var candidates = await _mediator.Send(new GetAllCandidatesQuery());
        return candidates;
    }

    [HttpGet("{uid}")]
    public async Task<GetCandidateQueryResult> Get(Guid uid)
    {
        var candidate = await _mediator.Send(new GetCandidateQuery(uid));
        return candidate;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<CreateCandidateCommandResult>> Post(CreateCandidateCommand createCandidateCommand)
    {
        var response = await _mediator.Send(createCandidateCommand);

        return response;
    }

    [HttpPut("{uid}")]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<UpdateCandidateCommandResult>> Put(UpdateCandidateCommand updateCandidateCommand)
    {
        var result = await _mediator.Send(updateCandidateCommand);
        return Ok(result);
    }

    [HttpDelete("{uid}")]
    public async Task<ActionResult<DeleteCandidateCommandResult>> Delete(DeleteCandidateCommand deleteCandidateCommand)
    {
        var result = await _mediator.Send(deleteCandidateCommand);
        return Ok(result);
    }
}
