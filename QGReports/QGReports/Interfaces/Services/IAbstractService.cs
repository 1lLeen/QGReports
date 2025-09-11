using QGReports.Domain.Interfaces.IDtos; 

namespace QGTransoarent.Application.Interfaces.InterfacesService;
public interface IAbstractService<TGet, TCreate, TUpdate>
    where TGet : IGet
    where TCreate : ICreate
    where TUpdate : IUpdate
{
    Task<List<TGet>> GetAllAsync();
    Task<TGet> GetByIdAsync(int id);
    Task<TGet> CreateAsync(TCreate entity);
    Task<TGet> UpdateAsync(TUpdate entity);
    Task<TGet> DeleteAsync(int id);
}
