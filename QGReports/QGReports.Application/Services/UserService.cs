using AutoMapper; 
using QGReports.Domain.Dtos.UsersDtos;
using QGReports.Domain.Interfaces.Repositories;
using QGReports.Domain.Interfaces.Services;
using QGReports.Domain.Models;

namespace QGReports.Application.Services;
public class UserService : AbstractService<IUserRepos, UserModel, GetUserDto, CreateUserDto, UpdateUserDto>,
    IUserService
{
    public UserService(IMapper mapper, IUserRepos repository) : base(mapper, repository)
    {
    }
}
