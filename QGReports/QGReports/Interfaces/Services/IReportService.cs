using QGReports.Domain.Dtos.ReportDtos;
using QGReports.Domain.Models;
using QGTransoarent.Application.Interfaces.InterfacesService;

namespace QGReports.Domain.Interfaces.Services;
public interface IReportService : IAbstractService<GetReportDto, CreateReportDto, UpdateReportDto>
{
    Task<List<ReportModel>> GetReportsByUserIdAsync(string userId);
    Task<List<ReportModel>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<List<ReportModel>> GetReportsByTitleAsync(string title);
    Task<List<ReportModel>> GetReportsByDistanceRangeAsync(double minDistance, double maxDistance);
    Task<List<ReportModel>> GetReportsByFuelUsedRangeAsync(double minFuelUsed, double maxFuelUsed);
    Task<List<ReportModel>> GetReportsByUpdateAsync();
    Task<List<ReportModel>> GetReportsByCreationAsync();
}
