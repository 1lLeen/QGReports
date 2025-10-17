using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Dtos.ImageDtos;
public class UpdateImageDto : BaseImageDto, IUpdate
{
    public DateTime UpdatedTime { get; set; }
}

