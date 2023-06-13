using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;

public class
  GetLeaveAllocationDetailsHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, LeaveAllocationDetailsDto>
{
  private readonly ILeaveAllocationRepository _leaveAllocationRepository;
  private readonly IMapper _mapper;

  public GetLeaveAllocationDetailsHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
  {
    _mapper = mapper;
    _leaveAllocationRepository = leaveAllocationRepository;
  }

  public async Task<LeaveAllocationDetailsDto> Handle(GetLeaveAllocationDetailsQuery request,
    CancellationToken cancellationToken)
  {
    var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

    return _mapper.Map<LeaveAllocationDetailsDto>(leaveAllocation);
  }
}