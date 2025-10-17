using QGReports.Domain.Models;

namespace QGReports.Domain.Interfaces.Repositories;
public interface IImageRepos : IAbstractRepoistory<ImageModel>
{
    Task<ImageModel> GetImageByUniquieId(string uniqueId);
    Task<List<ImageModel>> GetImagesByReportId(int reportId);
    Task<List<ImageModel>> GetImagesByUserId(int userId);
}
