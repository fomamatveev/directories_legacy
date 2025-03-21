using DL.Core.Interfaces;
using DL.Core.Models;

namespace DL.Directories.Interfaces;

public interface IDirectoriesRepository2<T> : IRepository<T> where T : Entity
{
    
}