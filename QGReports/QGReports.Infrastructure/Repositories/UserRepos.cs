using Microsoft.EntityFrameworkCore;
using QGReports.Domain.Enums;
using QGReports.Domain.Interfaces.Repositories;
using QGReports.Domain.Models;

namespace QGReports.Infrastructure.Repositories;
public class UserRepos : IUserRepos
{
    protected QGReportsDbContext _context;
    protected DbSet<UserModel> _dbSet;
    public UserRepos(QGReportsDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<UserModel>();
    }
    public async Task<UserModel> CreateAsync(UserModel model)
    {
        model.CreatedTime = DateTime.UtcNow;
        model.UpdatedTime = DateTime.UtcNow;

        await _dbSet.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }
    public async Task DeleteAsync(UserModel model)
    {
        _dbSet.Remove(model);
        await _context.SaveChangesAsync();
    }

    public async Task<IQueryable<UserModel>> GetAllAsync()
    {
        var res = await _dbSet.ToListAsync();
        return res.AsQueryable();
    }

    public async Task<UserModel> GetByIdAsync(Guid id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<UserModel> UpdateAsync(UserModel model)
    {
        model.UpdatedTime = DateTime.UtcNow;
        var local = _context.Set<UserModel>()
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
    public IQueryable<UserModel> GetUsersByEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return _context.Users.AsQueryable();
        }
        return _context.Users.Where(u => EF.Functions.Like(u.Email, $"%{email}%"));
    }
    public IQueryable<UserModel> GetUsersByFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return _context.Users.AsQueryable();
        }
        return _context.Users.Where(u => EF.Functions.Like(u.FirstName, $"%{firstName}%"));
    }
    public IQueryable<UserModel> GetUsersByLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return _context.Users.AsQueryable();
        }
        return _context.Users.Where(u => EF.Functions.Like(u.LastName, $"%{lastName}%"));
    }

    public IQueryable<UserModel> GetUsersByMiddleName(string middleName)
    {
        if (string.IsNullOrWhiteSpace(middleName))
        {
            return _context.Users.AsQueryable();
        }
        return _context.Users.Where(u => u.MiddleName != null && EF.Functions.Like(u.MiddleName, $"%{middleName}%"));
    }

    public IQueryable<UserModel> GetUsersByPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            return _context.Users.AsQueryable();
        }
        string normalizedPhone = new string(phone.Where(char.IsDigit).ToArray());
        return _context.Users.Where(u => EF.Functions.Like(u.Phone.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", ""), $"%{normalizedPhone}%"));
    }

    public IQueryable<UserModel> GetUsersByRole(Roles role)
    {
        return _context.Users.Where(x => x.Role == role).AsQueryable();
    }

   
}
