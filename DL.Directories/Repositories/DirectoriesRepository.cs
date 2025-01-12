using DL.BaseRepo.Repositories;
using DL.Directories.Data;
using DL.Directories.Interfaces;
using DL.Directories.Models;

namespace DL.Directories.Repositories;

public class DirectoriesRepository<T> : Repository<T>, IDirectoriesRepository<T> where T : Entity
{
    public DirectoriesRepository(DirectoriesDbContext context) : base(context) { }
}