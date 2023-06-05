using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
  private readonly HrDatabaseContext _context;

  public LeaveTypeRepository(HrDatabaseContext context) : base(context)
  {
    _context = context;
  }

  public async Task<bool> IsLeaveTypeUnique(string name)
  {
    return await _context.LeaveTypes.AnyAsync(q => q.Name.Equals(name));
  }
}