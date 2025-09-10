using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Models;
public class EquipmentModel : BaseModel, IGetIdModel
{ 
    public string? Name { get; set; }
    public int? Count { get; set; } 
}
