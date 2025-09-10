using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Dtos.ReportDtos;
public class BaseReportDto : IBase
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Comments { get; set; }
}
