using QGReports.Domain.Models;

namespace QGReports.Domain.Interfaces.Repositories;
public interface IReportRepos : IAbstractRepoistory<ReportModel>
{
    IQueryable<ReportModel> GetReprotsByUserId(Guid userId);
    IQueryable<ReportModel> GetReportsByDateRange(DateTime startDate, DateTime endDate);
    IQueryable<ReportModel> GetReportsByTitle(string title);
    IQueryable<ReportModel> GetReportsByDistanceRange(double minDistance, double maxDistance);
    IQueryable<ReportModel> GetReportsByFuelUsedRange(double minFuelUsed, double maxFuelUsed);
    IQueryable<ReportModel> GetReportsByUpdate();
    IQueryable<ReportModel> GetReportsByCreation();
}
