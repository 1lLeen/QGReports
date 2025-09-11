using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Models;
public class EquipmentModel : BaseModel
{ 
    public string? Name { get; set; }
    public int? Count { get; set; }
    public int? LastUsedUserId { get; set; }
}
