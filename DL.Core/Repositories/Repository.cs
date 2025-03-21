﻿using DL.Core.Data;
using DL.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DL.Core.Repositories;

public class Repository<T> : IRepository<T> 
    where T : class
{
    private readonly DirectoriesDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(DirectoriesDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IQueryable<T> GetAll() => _dbSet.AsQueryable();

    public async Task<T> GetByIdAsync(long id) => await _dbSet.FindAsync(id);

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}