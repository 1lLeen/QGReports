using QGReports.Domain.Interfaces;

namespace QGReports.Domain.Dtos.EquipmentDtos;
public class CreateEquipmentDto : BaseEquipmentDto, ICreate
{
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTIme { get; set; }
}
