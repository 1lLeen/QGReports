using QGReports.Domain.Dtos.UsersDtos;
using QGTransoarent.Application.Interfaces.InterfacesService;

namespace QGReports.Domain.Interfaces.Services;
public interface IUserService : IAbstractService<GetUserDto, CreateUserDto, UpdateUserDto>
{
}
