using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task4.Application.Commands;
using Task4.Application.Queries;
using Task4.Common.DTOs;

namespace Task4.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PositionsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<PositionDto>>> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllPositionsQuery()));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreatePositionCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdatePositionCommand command)
    {
        if (id != command.Id) return BadRequest("ID mismatch");
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeletePositionCommand(id));
        return NoContent();
    }
}