using Core.Application.Features.Candidates.Commands.CreateCandidate;
using Core.Application.Features.Candidates.Commands.DeleteCandidate;
using Core.Application.Features.Candidates.Commands.UpdateCandidate;
using Core.Application.Features.Candidates.Queries.GetAllCandidates;
using Core.Application.Features.Candidates.Queries.GetCandidate;
using Core.Domain.Constants;
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
    [Authorize(Roles = BaseConstants.NonEmployeeRoles)]
    public async Task<GetAllCandidatesQueryResult> GetAllCandidates(string? searchTerm, string? sortColumn, string? sortOrder, int? pageNumber, int? pageSize)
    {
        var candidates = await _mediator.Send(new GetAllCandidatesQuery(searchTerm, sortColumn, sortOrder, pageNumber, pageSize));
        return candidates;
    }

    [HttpGet("{uid}")]
    [Authorize(Roles = BaseConstants.NonEmployeeRoles)]
    public async Task<GetCandidateQueryResult> Get(Guid uid)
    {
        var candidate = await _mediator.Send(new GetCandidateQuery(uid));
        return candidate;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize(Roles = BaseConstants.NonEmployeeRoles)]
    public async Task<ActionResult<CreateCandidateCommandResult>> Post(CreateCandidateCommand createCandidateCommand)
    {
        var response = await _mediator.Send(createCandidateCommand);

        return response;
    }

    [HttpPut("{uid}")]
    [ProducesDefaultResponseType]
    [Authorize(Roles = BaseConstants.NonEmployeeRoles)]
    public async Task<ActionResult<UpdateCandidateCommandResult>> Put(UpdateCandidateCommand updateCandidateCommand)
    {
        var result = await _mediator.Send(updateCandidateCommand);
        return Ok(result);
    }

    [HttpDelete("{uid}")]
    [Authorize(Roles = BaseConstants.NonEmployeeRoles)]
    public async Task<ActionResult<DeleteCandidateCommandResult>> Delete(DeleteCandidateCommand deleteCandidateCommand)
    {
        var result = await _mediator.Send(deleteCandidateCommand);
        return Ok(result);
    }
}
