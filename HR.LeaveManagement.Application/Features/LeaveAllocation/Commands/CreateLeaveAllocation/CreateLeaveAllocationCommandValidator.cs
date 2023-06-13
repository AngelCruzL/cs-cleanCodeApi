using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;

public class CreateLeaveAllocationCommandValidator : AbstractValidator<CreateLeaveAllocationCommand>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public CreateLeaveAllocationCommandValidator(ILeaveTypeRepository leaveTypeRepository)
  {
    _leaveTypeRepository = leaveTypeRepository;

    RuleFor(p => p.LeaveTypeId)
      .GreaterThan(0)
      .MustAsync(LeaveTypeMustExist)
      .WithMessage("{PropertyName} does not exist.");
  }

  private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
  {
    var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
    return leaveType != null;
  }
}