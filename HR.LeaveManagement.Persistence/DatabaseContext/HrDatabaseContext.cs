using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.DatabaseContext;

public class HrDatabaseContext : DbContext
{
  public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options, DbSet<LeaveType> leaveTypes,
    DbSet<LeaveAllocation> leaveAllocations, DbSet<LeaveRequest> leaveRequests) : base(options)
  {
    LeaveTypes = leaveTypes;
    LeaveAllocations = leaveAllocations;
    LeaveRequests = leaveRequests;
  }

  public DbSet<LeaveType> LeaveTypes { get; set; }
  public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
  public DbSet<LeaveRequest> LeaveRequests { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);

    base.OnModelCreating(modelBuilder);
  }

  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
               .Where(q => q.State is EntityState.Added or EntityState.Modified))
    {
      entry.Entity.DateModified = DateTime.Now;

      if (entry.State == EntityState.Added) entry.Entity.DateCreated = DateTime.Now;
    }

    return base.SaveChangesAsync(cancellationToken);
  }
}