using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;
  private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;
  private readonly IMapper _mapper;

  public GetLeaveTypesQueryHandler(
    IMapper mapper,
    ILeaveTypeRepository leaveTypeRepository,
    IAppLogger<GetLeaveTypesQueryHandler> logger
  )
  {
    _mapper = mapper;
    _leaveTypeRepository = leaveTypeRepository;
    _logger = logger;
  }

  public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
  {
    // Query the database
    var leaveTypes = await _leaveTypeRepository.GetAsync();

    // Convert data objects to DTO objects 
    var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

    // Log the data
    _logger.LogInformation("Leave types retrieved successfully");

    // Return the list of DTO objects
    return data;
  }
}