using Microsoft.EntityFrameworkCore;
using QGReports.Domain.Interfaces.Repositories;
using QGReports.Domain.Models;

namespace QGReports.Infrastructure.Repositories;
public class AbstractRepository<TModel> : IAbstractRepoistory<TModel> where TModel : BaseModel
{
    protected QGReportsDbContext _context;
    protected DbSet<TModel> _dbSet;
    public AbstractRepository(QGReportsDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TModel>();
    }
    public async Task<TModel> CreateAsync(TModel model)
    {
        model.CreatedTime = DateTime.UtcNow;
        model.UpdatedTime = DateTime.UtcNow;

        await _dbSet.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }
    public async Task DeleteAsync(TModel model)
    {
        _dbSet.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TModel>> GetAllAsync()
    {
        var res = await _dbSet.ToListAsync();
        return res;
    }

    public async Task<TModel> GetByIdAsync(Guid id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TModel> UpdateAsync(TModel model)
    {
        model.UpdatedTime = DateTime.UtcNow;
        var local = _context.Set<TModel>()
            .Local
            .FirstOrDefault(entry => entry.Id.Equals(model.Id));
        if (local != null)
        {
            _context.Entry(local).State = EntityState.Detached;
        }
        var entry = _context.Entry(model);
        entry.State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return model;

    }
}
