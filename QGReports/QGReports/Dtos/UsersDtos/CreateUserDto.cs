using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Dtos.UsersDtos;
public class CreateUserDto : BaseUserDto, ICreate
{
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
