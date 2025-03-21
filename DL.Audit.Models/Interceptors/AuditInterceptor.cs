using DL.Core;
using DL.Core.Extensions;
using DL.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DL.Audit.Models.Interceptors;

public class AuditInterceptor : SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuditInterceptor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        SavingChanges(eventData, result);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;
        if (context == null)
        {
            return result;
        }

        var actions = new List<AuditAction>();

        var userId = _httpContextAccessor.HttpContext.User.GetUserId();

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
            {
                var action = new AuditAction
                {
                    Action = (AuditActionEnum)entry.State,
                    EntityName = entry.Entity.GetType().Name,
                    EntityId = 1,
                    Changes = "Чет изменилось, хз",
                    UpdatedAt = DateTime.UtcNow,
                    UpdatedBy = userId,
                };

                actions.Add(action);
            }
        }

        if (actions.Any())
        {
            context.Set<AuditAction>().AddRange(actions);
        }

        return base.SavingChanges(eventData, result);
    }
}