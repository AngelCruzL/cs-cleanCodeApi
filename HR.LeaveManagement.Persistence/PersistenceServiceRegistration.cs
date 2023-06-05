using HR.LeaveManagement.Persistence.DatabaseContext;
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

    return services;
  }
}