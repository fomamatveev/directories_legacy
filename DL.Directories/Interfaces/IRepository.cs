using DL.Directories.Models;

namespace DL.Directories.Interfaces;

public interface IRepository<T> where T : Entity
{
    IQueryable<T> GetAll();
    Task<T> GetByIdAsync(long id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}