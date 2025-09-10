using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Models;
public class EquipmentModel : IGetIdModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int? Count { get; set; }

}
