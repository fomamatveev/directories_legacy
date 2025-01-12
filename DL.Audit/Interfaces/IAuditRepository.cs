using DL.BaseRepo.Interfaces;

namespace DL.Audit.Interfaces;

public interface IAuditRepository<T> : IRepository<T> where T : class
{
    
}