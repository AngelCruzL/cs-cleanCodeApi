using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;

public class DeleteLeaveAllocationCommand : IRequest, IRequest<Unit>
{
  public int Id { get; set; }
}