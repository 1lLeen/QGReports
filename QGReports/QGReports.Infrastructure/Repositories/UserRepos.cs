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

    public async Task<List<UserModel>> GetAllAsync()
    {
        var res = await _dbSet.ToListAsync();
        return res;
    }

    public async Task<UserModel> GetByIdAsync(string id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id.Contains(id));
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
    public async Task<List<UserModel>> GetUsersByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return await _context.Users.ToListAsync();
        }
        return await _context.Users.Where(u => EF.Functions.Like(u.Email, $"%{email}%")).ToListAsync();
    }

    public async Task<List<UserModel>> GetUsersByFirstNameAsync(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return await _context.Users.ToListAsync();
        }
        return await _context.Users.Where(u => EF.Functions.Like(u.FirstName, $"%{firstName}%")).ToListAsync();
    }

    public async Task<List<UserModel>> GetUsersByLastNameAsync(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return await _context.Users.ToListAsync();
        }
        return await _context.Users.Where(u => EF.Functions.Like(u.LastName, $"%{lastName}%")).ToListAsync();
    }

    public async Task<List<UserModel>> GetUsersByMiddleNameAsync(string middleName)
    {
        if (string.IsNullOrWhiteSpace(middleName))
        {
            return await _context.Users.ToListAsync();
        }
        return await _context.Users.Where(u => u.MiddleName != null && EF.Functions.Like(u.MiddleName, $"%{middleName}%")).ToListAsync();
    }

    public async Task<List<UserModel>> GetUsersByPhoneAsync(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            return await _context.Users.ToListAsync();
        }
        string normalizedPhone = new string(phone.Where(char.IsDigit).ToArray());
        return await _context.Users.Where(u => EF.Functions.Like(u.Phone.Replace("-", "").Replace(" ", "").Replace("(", "").Replace(")", ""), $"%{normalizedPhone}%")).ToListAsync();
    }

    public async Task<List<UserModel>> GetUsersByRoleAsync(Roles role)
    {
        return await _context.Users.Where(x => x.Role == role).ToListAsync();
    }
}
