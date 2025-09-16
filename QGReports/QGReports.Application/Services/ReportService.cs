using AutoMapper;
using QGReports.Domain.Dtos.ReportDtos;
using QGReports.Domain.Interfaces.Repositories;
using QGReports.Domain.Interfaces.Services;
using QGReports.Domain.Models;

namespace QGReports.Application.Services;
public class ReportService : AbstractService<IReportRepos, ReportModel, GetReportDto, CreateReportDto, UpdateReportDto>,
    IReportService
{
    public ReportService(IMapper mapper, IReportRepos repository) : base(mapper, repository)
    {
    }

    public async Task<List<ReportModel>> GetReportsByCreationAsync()
    {
        var reports = await _repository.GetReportsByCreationAsync();
        return reports;
    }

    public async Task<List<ReportModel>> GetReportsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        var reports = await _repository.GetReportsByDateRangeAsync(startDate, endDate);
        return reports;
    }

    public async Task<List<ReportModel>> GetReportsByDistanceRangeAsync(double minDistance, double maxDistance)
    {
        var reports = await _repository.GetReportsByDistanceRangeAsync(minDistance, maxDistance);
        return reports;
    }

    public async Task<List<ReportModel>> GetReportsByFuelUsedRangeAsync(double minFuelUsed, double maxFuelUsed)
    {
        var reports = await _repository.GetReportsByFuelUsedRangeAsync(minFuelUsed, maxFuelUsed);
        return reports;
    }

    public async Task<List<ReportModel>> GetReportsByTitleAsync(string title)
    {
        var reports = await _repository.GetReportsByTitleAsync(title);
        return reports;
    }

    public async Task<List<ReportModel>> GetReportsByUpdateAsync()
    {
        var reports = await _repository.GetReportsByUpdateAsync();
        return reports;
    }

    public async Task<List<ReportModel>> GetReportsByUserIdAsync(string userId)
    {
        var reports = await _repository.GetReportsByUserIdAsync(userId);
        return reports;
    }
}
