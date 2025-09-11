using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QGReports.Domain.Models;
using QGTransoarent.Application.Services.IdentityServices; 

namespace QGReports.Infrastructure;

public class InitializationDataBase
{
    public const string ConnectionString = "DefaultConnection";

    public static void Init(IHost host) 
    {
        Console.WriteLine("Init database");
        var config = host.Services.GetRequiredService<IConfiguration>();
        using var scope = host.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<QGReportsDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<InitializationDataBase>>();

        logger.LogInformation("Database rebuild started.");

        dbContext.Database.EnsureDeleted();
        dbContext.Database.Migrate();

        logger.LogInformation("Started initialization of primary data in the database.");

        var admin = GetInitialUser();
        
        dbContext.Users.AddRange(admin);
        dbContext.Equipments.AddRange(GetInitialEquipments(admin));
        dbContext.SaveChanges();

        logger.LogInformation("Database rebuild finished.");

    }
    private static UserModel GetInitialUser() =>
    new UserModel()
    {
        CreatedTime = DateTime.Now.ToUniversalTime(),
        UpdatedTime = DateTime.Now.ToUniversalTime(),
        Email = "mygoldencode@gmail.com",
        Phone = "87768236918",
        Role = Domain.Enums.Roles.Admin,
        FirstName = "Жангир",
        LastName = "Емишов",
        MiddleName = "Бауржанович",
        PasswordHash = PasswordEncryptService.Encrypt("123456789"),
    };
    private static List<EquipmentModel> GetInitialEquipments(UserModel initialUser) =>
    new List<EquipmentModel>
    {
        new EquipmentModel
        {
            CreatedTime = DateTime.Now.ToUniversalTime(),
            UpdatedTime = DateTime.Now.ToUniversalTime(),
            Name = "Каска", 
              
        },
        new EquipmentModel
        {
            CreatedTime = DateTime.Now.ToUniversalTime(),
            UpdatedTime = DateTime.Now.ToUniversalTime(),
            Name = "Перчатки",
        },
        new EquipmentModel
        {
            CreatedTime = DateTime.Now.ToUniversalTime(),
            UpdatedTime = DateTime.Now.ToUniversalTime(),
            Name = "Спецодежда", 
        }
    };
}
