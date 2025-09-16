using Microsoft.EntityFrameworkCore;
using QGReports.Domain.Interfaces.Repositories;
using QGReports.Domain.Models;

namespace QGReports.Infrastructure.Repositories;

public class ReportRepos : AbstractRepository<ReportModel>,
    IReportRepos
{
    public ReportRepos(QGReportsDbContext context) : base(context)
    {
    }

    public async Task<List<ReportModel>> GetReportsByCreationAsync()
    {
        return await _context.Reports.Where(x => x.CreatedTime >= DateTime.Now).Reverse().ToListAsync();
    }

    public async Task<List<ReportModel>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
       return await _context.Reports.Where(x => x.CreatedTime >= startDate && x.CreatedTime <= endDate)
        .OrderByDescending(x => x.CreatedTime)
        .ToListAsync();
    }

    // По диапазону дистанции
    public async Task<List<ReportModel>> GetReportsByDistanceRangeAsync(double minDistance, double maxDistance)
    {
        return await _context.Reports
            .Where(x => x.DistanceKM >= minDistance && x.DistanceKM <= maxDistance)
            .OrderByDescending(x => x.CreatedTime)
            .ToListAsync();
    }

    // По диапазону потраченного топлива
    public async Task<List<ReportModel>> GetReportsByFuelUsedRangeAsync(double minFuelUsed, double maxFuelUsed)
    {
        return await _context.Reports
            .Where(x => x.FuelUsedLiters >= minFuelUsed && x.FuelUsedLiters <= maxFuelUsed)
            .OrderByDescending(x => x.CreatedTime)
            .ToListAsync();
    }

    // По названию (поиск с Like)
    public async Task<List<ReportModel>> GetReportsByTitleAsync(string title)
    {
        return await _context.Reports
            .Where(x => EF.Functions.Like(x.Title, $"%{title}%"))
            .OrderByDescending(x => x.CreatedTime)
            .ToListAsync();
    }

    // Последние обновлённые отчёты
    public async Task<List<ReportModel>> GetReportsByUpdateAsync()
    {
        return await _context.Reports
            .OrderByDescending(x => x.UpdatedTime) // предполагаю, что есть поле UpdatedTime
            .ToListAsync();
    }

    // По пользователю
    public async Task<List<ReportModel>> GetReportsByUserIdAsync(string userId)
    {
        return await _context.Reports
            .Where(x => x.CreatedByUserId == userId)
            .OrderByDescending(x => x.CreatedTime)
            .ToListAsync();
    }
}
