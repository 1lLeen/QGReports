using QGReports.Domain.Interfaces;

namespace QGReports.Domain.Dtos.EquipmentDtos;
public class BaseEquipmentDto : IBase
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int? Count { get; set; }
}
