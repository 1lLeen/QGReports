using AutoMapper;

using QGReports.Domain.Interfaces.IDtos;
using QGReports.Domain.Interfaces.Repositories;
using QGReports.Domain.Models;

namespace QGReports.Application.Services;
public class AbstractService<TRepository, TModel, TGet, TCreate, TUpdate>
        where TRepository : IAbstractRepoistory<TModel>
        where TModel : BaseModel
        where TGet : IGet
        where TCreate : ICreate
        where TUpdate : IUpdate
{
    protected readonly TRepository _repository; 
    protected readonly IMapper mapper;
    public AbstractService(IMapper mapper, TRepository repository)
    {
        _repository = repository;
        this.mapper = mapper;
    }
    public async Task<TGet> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return mapper.Map<TGet>(entity);
    }
    public async Task<IQueryable<TGet>> GetAllAsync()
    {
        var entity = mapper.Map<List<TGet>>(await _repository.GetAllAsync());

        return mapper.Map<IQueryable<TGet>>(entity);
    }
    public async Task<TGet> CreateAsync(TCreate create)
    {
        var model = mapper.Map<TModel>(create);
        await _repository.CreateAsync(model);
        model = await _repository.GetByIdAsync(model.Id);
        var result = mapper.Map<TGet>(model);

        return result;
    }
    public async Task<TGet> UpdateAsync(TUpdate update)
    {
        var model = mapper.Map<TModel>(update);
        await _repository.UpdateAsync(model);
        model = await _repository.GetByIdAsync(model.Id);
        var result = mapper.Map<TGet>(model);

        return result;
    }
    public async Task<TGet> DeleteAsync(Guid id)
    {
        var model = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(model);
        var result = mapper.Map<TGet>(model);

        return result;
    }

}
