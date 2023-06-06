using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType;

public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
{
  private readonly ILeaveTypeRepository _leaveTypeRepository;

  public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
  {
    _leaveTypeRepository = leaveTypeRepository;

    RuleFor(p => p.Id)
      .NotNull()
      .MustAsync(LeaveTypeMustExist);

    RuleFor(p => p.Name)
      .NotEmpty().WithMessage("{PropertyName} is required.")
      .NotNull()
      .MaximumLength(70).WithMessage("{PropertyName} must not exceed 70 characters.");

    RuleFor(p => p.DefaultDays)
      .GreaterThan(1).WithMessage("{PropertyName} must be greater than 1.")
      .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
  }

  private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
  {
    var leaveType = await _leaveTypeRepository.GetByIdAsync(id);
    return leaveType != null;
  }
}