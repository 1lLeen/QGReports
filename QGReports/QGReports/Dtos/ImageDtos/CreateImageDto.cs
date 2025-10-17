using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Dtos.ImageDtos;
public class CreateImageDto : BaseImageDto, ICreate
{
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
