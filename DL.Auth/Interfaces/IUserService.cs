using DL.Auth.Models;
using DL.Core.Models.Auth;

namespace DL.Auth.Interfaces;

public interface IUserService
{
    public Task<List<User>> GetUserListAsync();

    public Task<User?> GetUserByIdAsync(int id);

    public Task<User?> GetUserByNameAsync(string username);

    public Task CreateAsync(User user);

    public Task UpdateAsync(User user);

    public Task DeleteAsync(int id);
}