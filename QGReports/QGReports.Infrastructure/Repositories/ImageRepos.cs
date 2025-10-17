using Microsoft.EntityFrameworkCore;
using QGReports.Domain.Interfaces.Repositories;
using QGReports.Domain.Models;

namespace QGReports.Infrastructure.Repositories;
public class ImageRepos : AbstractRepository<ImageModel>, IImageRepos
{
    public ImageRepos(QGReportsDbContext context) : base(context)
    {
    }

    public async Task<ImageModel> GetImageByUniquieId(string uniqueId)
    {
        return await _context.Images.FirstOrDefaultAsync(img => img.UniquieId == uniqueId);
    }

    public async Task<List<ImageModel>> GetImagesByReportId(int reportId)
    {
        return await _context.Images.Where(x => x.ReportId == reportId).ToListAsync();
    }

    public async Task<List<ImageModel>> GetImagesByUserId(int userId)
    {
        return await _context.Images.Where(x =>  userId == x.UserId).ToListAsync();
    }
}
