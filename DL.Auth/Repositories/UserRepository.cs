using DL.Auth.Data;
using DL.Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace DL.Auth.Repositories;

public class UserRepository(AuthDbContext dbContext)
{
    private readonly AuthDbContext _dbContext = dbContext;

    public async Task<List<User>> GetUserListAsync()
    {
        return await _dbContext.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> GetUserByNameAsync(string username)
    {
        var res = _dbContext.Users.ToList();
        
        return await _dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Username == username);
    }

    public async Task CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await GetUserByIdAsync(id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}