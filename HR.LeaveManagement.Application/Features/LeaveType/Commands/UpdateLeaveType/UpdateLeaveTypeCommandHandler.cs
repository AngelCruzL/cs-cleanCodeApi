using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;
  private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger;
  private readonly IMapper _mapper;

  public UpdateLeaveTypeCommandHandler(
    IMapper mapper,
    ILeaveTypeRepository leaveTypeRepository,
    IAppLogger<UpdateLeaveTypeCommandHandler> logger)
  {
    _mapper = mapper;
    _leaveTypeRepository = leaveTypeRepository;
    _logger = logger;
  }

  public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
  {
    // Validate incoming data
    var validator = new UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
    var validationResult = await validator.ValidateAsync(request, cancellationToken);

    if (validationResult.Errors.Any())
    {
      _logger.LogWarning($"Validation errors in update request for {nameof(LeaveType)} - {request.Id}");
      throw new BadRequestException("Invalid Leave type", validationResult);
    }

    // Convert to domain entity object
    var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

    // Save to database
    await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

    // Return Unit.Value
    return Unit.Value;
  }
}