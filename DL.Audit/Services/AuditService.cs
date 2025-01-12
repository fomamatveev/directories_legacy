using DL.Audit.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DL.Audit.Services;

public class AuditService : IAuditService
{
    private readonly IAuditRepository<Models.Audit> _repository;

    public AuditService(IAuditRepository<Models.Audit> repository)
    {
        _repository = repository;
    }

    public async Task<List<Models.Audit>> ListAsync()
    {
        var actions = await _repository.GetAll()
            .ToListAsync();

        return actions;
    }

    public async Task<Models.Audit> GetAsync(int id)
    {
        var action = await _repository.GetByIdAsync(id);

        if (action == null)
        {
            throw new KeyNotFoundException($"Audit action with ID {id} not found.");
        }

        return action;
    }

    public async Task<Models.Audit> CreateAsync(Models.Audit action)
    {
        ArgumentNullException.ThrowIfNull(action);

        var result = new Models.Audit
        {
            Id = action.Id,
            Action = action.Action,
            EntityName = action.EntityName,
            EntityId = action.EntityId,
            Changes = action.Changes,
            UpdatedAt = DateTime.UtcNow,
            ChangedBy = action.ChangedBy
        };
        
        await _repository.AddAsync(result);

        return result;
    }

    public Task<Models.Audit> UpdateAsync(Models.Audit action)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}