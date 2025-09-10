using QGReports.Domain.Interfaces;

namespace QGReports.Domain.Dtos.EquipmentDtos;
public  class UpdateEquipmentDto : BaseEquipmentDto, IUpdate
{
    public DateTime UpdatedTime { get; set; }
}
