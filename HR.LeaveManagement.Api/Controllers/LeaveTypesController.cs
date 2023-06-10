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
  public void Post([FromBody] string value)
  {
  }

  // PUT: api/LeaveTypes/5
  [HttpPut("{id}")]
  public void Put(int id, [FromBody] string value)
  {
  }

  // DELETE: api/LeaveTypes/5
  [HttpDelete("{id}")]
  public void Delete(int id)
  {
  }
}