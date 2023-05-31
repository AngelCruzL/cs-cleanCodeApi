using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveType:BaseEntity
{
  public string Name { get; set; }
  public int DefaultDays { get; set; }
}