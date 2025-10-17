namespace QGReports.Domain.Models;
public class ImageModel : BaseModel
{
    public string UniquieId { get; set; }
    public byte Data { get; set; }
    public int UserId { get; set; }
    public int? ReportId { get; set; }
}
