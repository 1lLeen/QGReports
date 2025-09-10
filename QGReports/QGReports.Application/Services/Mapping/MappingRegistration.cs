using Microsoft.Extensions.DependencyInjection;

namespace QGReports.Application.Services.Mapping;
public static class MappingRegistration
{
    public static void RegistrationAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
    }
}
