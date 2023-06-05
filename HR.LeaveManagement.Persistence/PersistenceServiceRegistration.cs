using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.DatabaseContext;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistence;

public static class PersistenceServiceRegistration
{
  public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
    IConfiguration configuration)
  {
    services.AddDbContext<HrDatabaseContext>(opt =>
    {
      opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    });

    services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
    services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
    services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

    return services;
  }
}