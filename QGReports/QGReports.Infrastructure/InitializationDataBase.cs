using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QGReports.Domain.Enums;
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
        admin.PasswordHash = new PasswordHasher<UserModel>().HashPassword(admin, "NewPasswordForMe1112");
        dbContext.Users.Add(admin);
        dbContext.Equipments.AddRange(GetInitialEquipments(admin));
        dbContext.Roles.AddRange(GetRoles());
        dbContext.SaveChanges();
        dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = dbContext.Roles.First(x => x.Name == Roles.Admin.ToString()).Id.ToString(),
            UserId = dbContext.Users.First().Id
        });
        dbContext.SaveChanges();

        logger.LogInformation("Database rebuild finished.");
    }
    private static List<IdentityRole> GetRoles() => new List<IdentityRole>
        {
            new IdentityRole
            {
                Name = Roles.Admin.ToString(),
                NormalizedName = Roles.Admin.ToString().ToUpper(),
            },
            new IdentityRole
            {
                Name = Roles.General.ToString(),
                NormalizedName = Roles.General.ToString().ToUpper(),
            },new IdentityRole
            {
                Name = Roles.Supervisor.ToString(),
                NormalizedName = Roles.Supervisor.ToString().ToUpper(),
            },new IdentityRole
            {
                Name = Roles.Tester.ToString(),
                NormalizedName = Roles.Tester.ToString().ToUpper(),
            },new IdentityRole
            {
                Name = Roles.Geologist.ToString(),
                NormalizedName = Roles.Geologist.ToString().ToUpper(),
            },new IdentityRole
            {
                Name = Roles.Driver.ToString(),
                NormalizedName = Roles.Driver.ToString().ToUpper(),
            },new IdentityRole
            {
                Name = Roles.Employee.ToString(),
                NormalizedName = Roles.Employee.ToString().ToUpper(),
            },
        };
    private static UserModel GetInitialUser() =>
    new UserModel()
    {
        CreatedTime = DateTime.Now.ToUniversalTime(),
        UpdatedTime = DateTime.Now.ToUniversalTime(),
        Email = "mygoldencode@gmail.com",
        Role = Domain.Enums.Roles.Admin,
        FirstName = "Жангир",
        LastName = "Емишов",
        MiddleName = "Бауржанович",
        UserName = "mygoldencode@gmail.com",
        NormalizedUserName = "mygoldencode@gmail.com".ToUpper().Normalize(),
        NormalizedEmail = "mygoldencode@gmail.com".ToUpper().Normalize(),
        PhoneNumber = "87768236918",
        PhoneNumberConfirmed = true,
        EmailConfirmed = true,
        
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
