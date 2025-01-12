using DL.Audit.Data;
using DL.Audit.Interfaces;
using DL.BaseRepo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DL.Audit.Repositories;

public class AuditRepository<T> : Repository<T>, IAuditRepository<T> where T : class
{
    public AuditRepository(AuditDbContext context) : base(context)
    {
    }
}