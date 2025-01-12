using DL.BaseRepo.Interfaces;
using DL.Directories.Models;

namespace DL.Directories.Interfaces;

public interface IDirectoriesRepository<T> : IRepository<T> where T : Entity
{
    
}