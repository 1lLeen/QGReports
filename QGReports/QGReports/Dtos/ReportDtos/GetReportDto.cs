using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Dtos.ReportDtos;
public class GetReportDto : BaseReportDto, IGet
{
    public Guid? CreatedByUserId { get; set; }
    public string? Content { get; set; }
    public string? UsersMovement { get; set; }
    public string? EquipmentsMovement { get; set; }
}
