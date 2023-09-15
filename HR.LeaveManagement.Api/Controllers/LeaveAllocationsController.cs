using HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveAllocationsController : ControllerBase
{
  private readonly IMediator _mediator;

  public LeaveAllocationsController(IMediator mediator)
  {
    _mediator = mediator;
  }

  // GET: api/LeaveAllocations
  [HttpGet]
  public async Task<ActionResult<LeaveAllocationDto>> Get(bool isLoggedInUser = false)
  {
    var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListQuery());
    return Ok(leaveAllocations);
  }

  // GET: api/LeaveAllocations/5
  [HttpGet("{id}", Name = "Get")]
  public async Task<ActionResult<LeaveAllocationDetailsDto>> Get(int id)
  {
    var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailsQuery { Id = id });
    return Ok(leaveAllocation);
  }

  // POST: api/LeaveAllocations
  [HttpPost]
  [ProducesResponseType(201)]
  [ProducesResponseType(400)]
  [ProducesResponseType(StatusCodes.Status404NotFound)]
  public async Task<ActionResult> Post(CreateLeaveAllocationCommand leaveAllocation)
  {
    var response = await _mediator.Send(leaveAllocation);
    return CreatedAtAction(nameof(Get), new { id = response }, response);
  }

  // PUT: api/LeaveAllocations/5
  [HttpPut("{id}")]
  public void Put(int id, [FromBody] string value)
  {
  }

  // DELETE: api/LeaveAllocations/5
  [HttpDelete("{id}")]
  public void Delete(int id)
  {
  }
}