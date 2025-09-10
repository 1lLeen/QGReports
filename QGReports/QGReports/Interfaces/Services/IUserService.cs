using QGReports.Domain.Dtos.UsersDtos;
using QGReports.Domain.Enums;
using QGReports.Domain.Models;
using QGTransoarent.Application.Interfaces.InterfacesService;

namespace QGReports.Domain.Interfaces.Services;
public interface IUserService : IAbstractService<GetUserDto, CreateUserDto, UpdateUserDto>
{

    Task<List<UserModel>> GetUsersByFirstNameAsync(string firstName);
    Task<List<UserModel>> GetUsersByLastNameAsync(string lastName);
    Task<List<UserModel>> GetUsersByMiddleNameAsync(string middleName);
    Task<List<UserModel>> GetUsersByPhoneAsync(string phone);
    Task<List<UserModel>> GetUsersByEmailAsync(string email);
    Task<List<UserModel>> GetUsersByRoleAsync(Roles role);
}
