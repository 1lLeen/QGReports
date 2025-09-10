namespace QGReports.Domain.Models;
public class ReportModel : BaseModel
{ 
    public Guid? CreatedByUserId { get; set; }
    public string? Content { get; set; }
    public string? Title { get; set; }
    public string? Comments { get; set; }
    public double? DistanceKM { get; set; }
    public double? FuelUsedLiters { get; set; }
    public string? RouteDescription { get; set; }
    public string? UsersMovement { get; set; }
    public string? EquipmentsMovement { get; set; }
    public DateTime? DepartureTime { get; set; }
    public DateTime? ArrivalTime { get; set; } 
}
