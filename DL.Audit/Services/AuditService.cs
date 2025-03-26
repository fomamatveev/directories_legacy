using DL.Audit.Dtos;
using DL.Audit.Interfaces;
using DL.Auth.Interfaces;
using DL.Auth.Models;
using DL.Core.Extensions;
using DL.Core.Interfaces;
using DL.Core.Models;
using DL.Core.Models.Audit;
using DL.Core.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace DL.Audit.Services;

public class AuditService : IAuditService
{
    private readonly IRepository<AuditAction> _repository;
    private readonly IRepository<User> _user;
    private readonly IRepository<EntityType> _entityType;

    public AuditService(IRepository<AuditAction> repository, IRepository<User> user, IRepository<EntityType> entityType)
    {
        _repository = repository;
        _user = user;
        _entityType = entityType;
    }

    public async Task<List<AuditActionDto>> ListAsync()
    {
        var actions = await _repository.GetAll()
            .OrderByDescending(a => a.Id)
            .Join(_user.GetAll(),
                a => a.UpdatedBy,
                u => u.Id,
                (a, u) => new {Audit = a, User = u})
            .Join(_entityType.GetAll(),
                x => x.Audit.EntityId,
                et => et.EntityId,
                (x, et) => new { x.Audit, x.User, EntityType = et })
            .Select(x => new AuditActionDto
            {
                Id = x.Audit.Id,
                Action = x.Audit.Action.GetDescription(),
                EntityName = x.EntityType.EntityName,
                Changes = x.Audit.Changes,
                UpdatedAt = x.Audit.UpdatedAt,
                UpdatedBy = x.User.Username
            })
            .ToListAsync();

        return actions;
    }
}