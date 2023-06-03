using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;

public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public DeleteLeaveTypeCommandHandler( ILeaveTypeRepository leaveTypeRepository)
  {
    _leaveTypeRepository = leaveTypeRepository;
  }

  public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
  {
    // Retrieve domain entity object
    var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);
    
    // Verify that the entity exists
    
    // Delete from database
    await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
    
    return Unit.Value;
  }
}