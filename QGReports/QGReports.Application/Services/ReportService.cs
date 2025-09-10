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
}
