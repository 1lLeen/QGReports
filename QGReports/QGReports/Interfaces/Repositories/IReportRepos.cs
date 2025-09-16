using QGReports.Domain.Models;

namespace QGReports.Domain.Interfaces.Repositories;
public interface IReportRepos : IAbstractRepoistory<ReportModel>
{
    Task<List<ReportModel>> GetReportsByUserIdAsync(string userId);
    Task<List<ReportModel>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<List<ReportModel>> GetReportsByTitleAsync(string title);
    Task<List<ReportModel>> GetReportsByDistanceRangeAsync(double minDistance, double maxDistance);
    Task<List<ReportModel>> GetReportsByFuelUsedRangeAsync(double minFuelUsed, double maxFuelUsed);
    Task<List<ReportModel>> GetReportsByUpdateAsync();
    Task<List<ReportModel>> GetReportsByCreationAsync();
}
