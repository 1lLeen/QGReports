using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Dtos.EquipmentDtos;
public class CreateEquipmentDto : BaseEquipmentDto, ICreate
{
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
