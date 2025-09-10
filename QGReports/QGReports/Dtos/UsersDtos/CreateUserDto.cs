using QGReports.Domain.Interfaces;

namespace QGReports.Domain.Dtos.UsersDtos;
public class CreateUserDto : UserDto, ICreate
{
    public DateTime CreatedTime { get; set; }
}
