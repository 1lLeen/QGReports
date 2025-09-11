using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QGReports.Application;
using QGReports.Domain.Interfaces.Repositories;
using QGReports.Infrastructure.Repositories;

namespace QGReports.Infrastructure;
public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<QGReportsDbContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString(InitializationDataBase.ConnectionString)));

        builder.Services.RegistrationAutoMapper(); 
        builder.Services.RegistrationRepositories();
        builder.Services.RegistrationServices();
    }
    public static void RegistrationRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepos, UserRepos>();
        services.AddTransient<IEquipmentRepos, EquipmentRepos>();
        services.AddTransient<IReportRepos, ReportRepos>();
    }
}
