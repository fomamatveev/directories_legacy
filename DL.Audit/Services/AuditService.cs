using DL.Audit.Dtos;
using DL.Audit.Interfaces;
using DL.Auth.Interfaces;
using DL.Auth.Models;
using DL.Core.Interfaces;
using DL.Core.Models;
using DL.Core.Models.Auth;
using Microsoft.EntityFrameworkCore;

namespace DL.Audit.Services;

public class AuditService : IAuditService
{
    private readonly IRepository<AuditAction> _repository;
    private readonly IRepository<User> _user;

    public AuditService(IRepository<AuditAction> repository, IRepository<User> user)
    {
        _repository = repository;
        _user = user;
    }

    public async Task<List<AuditActionDto>> ListAsync()
    {
        var actions = await _repository.GetAll()
            .OrderByDescending(a => a.Id)
            .Join(_user.GetAll(),
                a => a.UpdatedBy,
                u => u.Id,
                (a, u) => new {Audit = a, User = u})
            .Select(x => new AuditActionDto
            {
                Id = x.Audit.Id,
                Action = x.Audit.Action.ToString(),
                EntityName = x.Audit.EntityName,
                EntityId = x.Audit.EntityId,
                Changes = x.Audit.Changes,
                UpdatedAt = x.Audit.UpdatedAt,
                UpdatedBy = x.User.Username
            })
            .ToListAsync();

        return actions;
    }
}