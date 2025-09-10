using QGReports.Domain.Interfaces.IDtos; 

namespace QGTransoarent.Application.Interfaces.InterfacesService;
public interface IAbstractService<TGet, TCreate, TUpdate>
    where TGet : IGet
    where TCreate : ICreate
    where TUpdate : IUpdate
{
    public Task<IQueryable<TGet>> GetAllAsync();
    public Task<TGet> GetByIdAsync(Guid id);
    public Task<TGet> CreateAsync(TCreate entity);
    public Task<TGet> UpdateAsync(TUpdate entity);
    public Task<TGet> DeleteAsync(Guid id);
}
