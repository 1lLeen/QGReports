using AutoMapper;
using QGReports.Domain.Dtos.UsersDtos;
using QGReports.Domain.Interfaces.Repositories;
using QGReports.Domain.Interfaces.Services;
using QGReports.Domain.Models;

namespace QGReports.Application.Services;
public class UserService : IUserService
{
    protected readonly IUserRepos _repository;
    protected readonly IMapper mapper;
    public UserService(IMapper mapper, IUserRepos repository)
    {
        _repository = repository;
        this.mapper = mapper;
    }
    public async Task<GetUserDto> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return mapper.Map<GetUserDto>(entity);
    }
    public async Task<IQueryable<GetUserDto>> GetAllAsync()
    {
        var entity = mapper.Map<List<GetUserDto>>(await _repository.GetAllAsync());

        return mapper.Map<IQueryable<GetUserDto>>(entity);
    }
    public async Task<GetUserDto> CreateAsync(CreateUserDto create)
    {
        var model = mapper.Map<UserModel>(create);
        await _repository.CreateAsync(model);
        model = await _repository.GetByIdAsync(model.Id);
        var result = mapper.Map<GetUserDto>(model);

        return result;
    }
    public async Task<GetUserDto> UpdateAsync(UpdateUserDto update)
    {
        var model = mapper.Map<UserModel>(update);
        await _repository.UpdateAsync(model);
        model = await _repository.GetByIdAsync(model.Id);
        var result = mapper.Map<GetUserDto>(model);

        return result;
    }
    public async Task<GetUserDto> DeleteAsync(Guid id)
    {
        var model = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(model);
        var result = mapper.Map<GetUserDto>(model);

        return result;
    }
}
