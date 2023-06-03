using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;
  private readonly IMapper _mapper;

  public UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
  {
    _mapper = mapper;
    _leaveTypeRepository = leaveTypeRepository;
  }

  public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
  {
    // Validate incoming data

    // Convert to domain entity object
    var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

    // Save to database
    await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

    // Return Unit.Value
    return Unit.Value;
  }
}