namespace DL.Core.Interfaces;

public interface IRepository<T>
{
    IQueryable<T> GetAll();
    Task<T> GetByIdAsync(long id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}