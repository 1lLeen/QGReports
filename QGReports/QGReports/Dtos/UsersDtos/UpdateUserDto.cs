using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Dtos.UsersDtos;
public class UpdateUserDto : BaseUserDto, IUpdate
{
    public DateTime UpdatedTime { get; set; }
}
