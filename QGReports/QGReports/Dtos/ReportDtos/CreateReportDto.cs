using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Dtos.ReportDtos;
public class CreateReportDto : BaseReportDto, ICreate
{
    public Guid? CreatedByUserId { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
    public string? Content { get; set; } 
    public double? DistanceKM { get; set; }
    public double? FuelUsedLiters { get; set; }
    public string? RouteDescription { get; set; }
    public string? UsersMovement { get; set; }
    public string? EquipmentsMovement { get; set; }
    public DateTime? DepartureTime { get; set; }
    public DateTime? ArrivalTime { get; set; }
}
