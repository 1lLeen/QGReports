namespace QGReports.Domain.Interfaces.Repositories;

public interface IAbstractRepoistory<TModel> where TModel : class
{
    Task<TModel> CreateAsync(TModel model);
    Task<TModel> UpdateAsync(TModel model);
    Task DeleteAsync(TModel model);
    Task<TModel> GetByIdAsync(Guid id);
    Task<IEnumerable<TModel>> GetAllAsync();
}