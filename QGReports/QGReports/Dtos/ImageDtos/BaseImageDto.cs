using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Dtos.ImageDtos;
public class BaseImageDto : IBase
{
    public int Id { get; set; }
    public string UniquieId { get; set; }
    public byte Date { get; set; }
    public int UserId { get; set; }
    public int? ReportId { get; set; }
}
