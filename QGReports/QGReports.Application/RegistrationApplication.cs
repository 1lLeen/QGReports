using Microsoft.Extensions.DependencyInjection;
using QGReports.Application.Services;
using QGReports.Application.Services.Mapping;
using QGReports.Domain.Interfaces.Services;

namespace QGReports.Application;
public static class RegistrationApplication
{
    public static void RegistrationAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
    }
    public static void RegistrationServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IEquipmentService, EquipmentService>();
        services.AddTransient<IReportService, ReportService>();
    }
}
