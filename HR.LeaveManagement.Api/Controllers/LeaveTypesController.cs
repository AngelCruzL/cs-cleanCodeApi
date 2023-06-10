using HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController : ControllerBase
{
  private readonly IMediator _mediator;

  public LeaveTypesController(IMediator mediator)
  {
    _mediator = mediator;
  }

  // GET: api/LeaveTypes
  [HttpGet]
  public async Task<List<LeaveTypeDto>> Get()
  {
    return await _mediator.Send(new GetLeaveTypesQuery());
  }

  // GET: api/LeaveTypes/5
  [HttpGet("{id}", Name = "Get")]
  public async Task<LeaveTypeDetailsDto> Get(int id)
  {
    return await _mediator.Send(new GetLeaveTypeDetailsQuery(id));
  }

  // POST: api/LeaveTypes
  [HttpPost]
  [ProducesResponseType(201)]
  [ProducesResponseType(400)]
  public async Task<ActionResult> Post(CreateLeaveTypeCommand leaveType)
  {
    var response = await _mediator.Send(leaveType);
    return CreatedAtAction(nameof(Get), new { id = response }, response);
  }

  // PUT: api/LeaveTypes/5
  [HttpPut("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  public async Task<ActionResult> Put(UpdateLeaveTypeCommand leaveType)
  {
    await _mediator.Send(leaveType);
    return NoContent();
  }

  // DELETE: api/LeaveTypes/5
  [HttpDelete("{id}")]
  [ProducesResponseType(StatusCodes.Status204NoContent)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  [ProducesDefaultResponseType]
  public async Task<ActionResult> Delete(int id)
  {
    var command = new DeleteLeaveTypeCommand { Id = id };
    await _mediator.Send(command);
    return NoContent();
  }
}