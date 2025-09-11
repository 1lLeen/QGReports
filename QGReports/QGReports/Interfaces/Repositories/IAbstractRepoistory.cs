using QGReports.Domain.Interfaces.IDtos;
using QGReports.Domain.Models;

namespace QGReports.Domain.Interfaces.Repositories;

public interface IAbstractRepoistory<TModel> where TModel : BaseModel
{
    Task<TModel> CreateAsync(TModel model);
    Task<TModel> UpdateAsync(TModel model);
    Task DeleteAsync(TModel model);
    Task<TModel> GetByIdAsync(int id);
    Task<List<TModel>> GetAllAsync();
}