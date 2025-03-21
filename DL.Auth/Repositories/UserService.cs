using DL.Auth.Data;
using DL.Auth.Interfaces;
using DL.Auth.Models;
using DL.Core;
using DL.Core.Data;
using DL.Core.Interfaces;
using DL.Core.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace DL.Auth.Repositories;

public class UserService(DirectoriesDbContext dbContext, IRepository<User> userRepository) : IUserService
{
    private readonly IRepository<User> _userRepository = userRepository;

    public async Task<List<User>> GetUserListAsync()
    {
        return await _userRepository.GetAll()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetAll()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<User?> GetUserByNameAsync(string username)
    {
        var res = _userRepository.GetAll().ToList();
        
        return await _userRepository.GetAll()
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Username == username);
    }

    public async Task CreateAsync(User user)
    {
        await _userRepository.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(User user)
    {
        await _userRepository.UpdateAsync(user);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await GetUserByIdAsync(id);
        if (user != null)
        {
            await _userRepository.DeleteAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}