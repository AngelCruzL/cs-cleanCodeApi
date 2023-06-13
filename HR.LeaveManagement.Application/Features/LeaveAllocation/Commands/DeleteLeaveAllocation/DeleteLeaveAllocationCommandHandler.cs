using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
{
  private readonly ILeaveAllocationRepository _leaveAllocationRepository;
  private readonly IMapper _mapper;

  public DeleteLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
  {
    _mapper = mapper;
    _leaveAllocationRepository = leaveAllocationRepository;
  }

  public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
  {
    var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.Id);

    if (leaveAllocation == null)
      throw new NotFoundException(nameof(Domain.LeaveAllocation), request.Id);

    await _leaveAllocationRepository.DeleteAsync(leaveAllocation);

    return Unit.Value;
  }
}