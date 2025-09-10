using QGReports.Domain.Enums;
using QGReports.Domain.Models;

namespace QGReports.Domain.Interfaces.Repositories;

public interface IUserRepos
{
    Task<UserModel> CreateAsync(UserModel model);
    Task<UserModel> UpdateAsync(UserModel model);
    Task DeleteAsync(UserModel model);
    Task<UserModel> GetByIdAsync(Guid id);
    Task<IQueryable<UserModel>> GetAllAsync();

    IQueryable<UserModel> GetUsersByFirstName(string firstName);
    IQueryable<UserModel> GetUsersByLastName(string lastName);
    IQueryable<UserModel> GetUsersByMiddleName(string middleName);
    IQueryable<UserModel> GetUsersByPhone(string phone);
    IQueryable<UserModel> GetUsersByEmail(string email);
    IQueryable<UserModel> GetUsersByRole(Roles role);

}
