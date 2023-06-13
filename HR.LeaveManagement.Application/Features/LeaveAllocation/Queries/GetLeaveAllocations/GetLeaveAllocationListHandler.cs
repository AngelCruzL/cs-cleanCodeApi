using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations;

public class GetLeaveAllocationListHandler : IRequestHandler<GetLeaveAllocationListQuery, List<LeaveAllocationDto>>
{
  private readonly ILeaveAllocationRepository _leaveAllocationRepository;
  private readonly IMapper _mapper;

  public GetLeaveAllocationListHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
  {
    _mapper = mapper;
    _leaveAllocationRepository = leaveAllocationRepository;
  }

  public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListQuery request,
    CancellationToken cancellationToken)
  {
    var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
    return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
  }
}