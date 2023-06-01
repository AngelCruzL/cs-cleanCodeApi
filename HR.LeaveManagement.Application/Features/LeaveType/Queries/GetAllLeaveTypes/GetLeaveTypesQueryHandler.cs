using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;

public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;
  private readonly IMapper _mapper;

  public GetLeaveTypesQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
  {
    _mapper = mapper;
    _leaveTypeRepository = leaveTypeRepository;
  }

  public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
  {
    var leaveTypes = await _leaveTypeRepository.GetAsync();

    return _mapper.Map<List<LeaveTypeDto>>(leaveTypes);
  }
}