using QGReports.Domain.Dtos.UsersDtos;
using QGReports.Domain.Enums;
using QGReports.Domain.Models;
using QGTransoarent.Application.Interfaces.InterfacesService;

namespace QGReports.Domain.Interfaces.Services;
public interface IUserService : IAbstractService<GetUserDto, CreateUserDto, UpdateUserDto>
{

    Task<List<GetUserDto>> GetUsersByFirstNameAsync(string firstName);
    Task<List<GetUserDto>> GetUsersByLastNameAsync(string lastName);
    Task<List<GetUserDto>> GetUsersByMiddleNameAsync(string middleName);
    Task<List<GetUserDto>> GetUsersByPhoneAsync(string phone);
    Task<List<GetUserDto>> GetUsersByEmailAsync(string email);
    Task<List<GetUserDto>> GetUsersByRoleAsync(Roles role);
}
