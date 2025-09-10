using QGReports.Domain.Models;

namespace QGReports.Domain.Interfaces.Repositories;

public interface IUserRepos : IAbstractRepoistory<UserModel>
{
    IQueryable<UserModel> GetUsersByFirstName(string firstName);
    IQueryable<UserModel> GetUsersByLastName(string lastName);
    IQueryable<UserModel> GetUsersByMiddleName(string middleName);
    IQueryable<UserModel> GetUsersByPhone(string phone);
    IQueryable<UserModel> GetUsersByEmail(string email);
    IQueryable<UserModel> GetUsersByRole(string role);

}
