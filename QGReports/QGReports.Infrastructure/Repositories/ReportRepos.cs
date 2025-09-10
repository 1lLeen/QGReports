using QGReports.Domain.Interfaces.Repositories;
using QGReports.Domain.Models;

namespace QGReports.Infrastructure.Repositories;

public class ReportRepos : AbstractRepository<ReportModel>,
    IReportRepos
{
    public ReportRepos(QGReportsDbContext context) : base(context)
    {
    }

    public IQueryable<ReportModel> GetReportsByCreation()
    {
        throw new NotImplementedException();
    }

    public IQueryable<ReportModel> GetReportsByDateRange(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public IQueryable<ReportModel> GetReportsByDistanceRange(double minDistance, double maxDistance)
    {
        throw new NotImplementedException();
    }

    public IQueryable<ReportModel> GetReportsByFuelUsedRange(double minFuelUsed, double maxFuelUsed)
    {
        throw new NotImplementedException();
    }

    public IQueryable<ReportModel> GetReportsByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public IQueryable<ReportModel> GetReportsByUpdate()
    {
        throw new NotImplementedException();
    }

    public IQueryable<ReportModel> GetReprotsByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }
}
