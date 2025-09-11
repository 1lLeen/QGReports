using QGReports.Domain.Enums;
using QGReports.Domain.Models;

namespace QGReports.Domain.Interfaces.Repositories;

public interface IUserRepos
{
    Task<UserModel> CreateAsync(UserModel model);
    Task<UserModel> UpdateAsync(UserModel model);
    Task DeleteAsync(UserModel model);
    Task<UserModel> GetByIdAsync(string id);
    Task<List<UserModel>> GetAllAsync();

    Task<List<UserModel>> GetUsersByFirstNameAsync(string firstName);
    Task<List<UserModel>> GetUsersByLastNameAsync(string lastName);
    Task<List<UserModel>> GetUsersByMiddleNameAsync(string middleName);
    Task<List<UserModel>> GetUsersByPhoneAsync(string phone);
    Task<List<UserModel>> GetUsersByEmailAsync(string email);
    Task<List<UserModel>> GetUsersByRoleAsync(Roles role);

}
