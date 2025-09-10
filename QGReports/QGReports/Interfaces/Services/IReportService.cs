using QGReports.Domain.Dtos.ReportDtos;
using QGTransoarent.Application.Interfaces.InterfacesService;

namespace QGReports.Domain.Interfaces.Services;
public interface IReportService : IAbstractService<GetReportDto, CreateReportDto, UpdateReportDto>
{
}
