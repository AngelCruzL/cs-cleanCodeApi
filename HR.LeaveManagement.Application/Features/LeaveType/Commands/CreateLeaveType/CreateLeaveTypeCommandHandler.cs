using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;
  private readonly IMapper _mapper;

  public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
  {
    _mapper = mapper;
    _leaveTypeRepository = leaveTypeRepository;
  }

  public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
  {
    // Validate incoming data
    var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
    var validationResult = await validator.ValidateAsync(request);

    if (validationResult.Errors.Any())
      throw new BadRequestException("Invalid LeaveType data", validationResult);

    // Convert to domain entity object
    var leaveTypeToCreate = _mapper.Map<Domain.LeaveType>(request);

    // Save to database
    await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);

    return leaveTypeToCreate.Id;
  }
}