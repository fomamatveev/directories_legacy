using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using DL.Core.Extensions;
using DL.Core.Models.Audit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        var userId = _httpContextAccessor.HttpContext?.Request.Path.StartsWithSegments("/auth/register") == true ? 1 : _httpContextAccessor.HttpContext.User.GetUserId();

        foreach (var entry in context.ChangeTracker.Entries())
        {
            var changes = GetEntityChanges(entry);
            
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
            {
                var action = new AuditAction
                {
                    Action = (AuditActionEnum)entry.State,
                    EntityName = entry.Entity.GetType().Name,
                    EntityId = Enum.Parse<EntityTypeEnum>(entry.Entity.GetType().Name),
                    Changes = changes,
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
    
    /// <summary>
    /// Получить изменения
    /// </summary>
    /// <param name="entry"></param>
    /// <returns></returns>
    private string GetEntityChanges(EntityEntry entry)
    {
        var operation = entry.State switch
        {
            EntityState.Added => AuditActionEnum.Create.ToString(),
            EntityState.Modified => AuditActionEnum.Update.ToString(),
            EntityState.Deleted => AuditActionEnum.Delete.ToString(),
            _ => null
        };

        if (operation == null) 
            return null;

        var changes = new Dictionary<string, object>();
        var values = entry.State == EntityState.Deleted 
            ? entry.OriginalValues 
            : entry.CurrentValues;

        foreach (var property in values.Properties)
        {
            changes.Add(property.Name, new
            {
                oldValue = entry.State != EntityState.Added ? entry.OriginalValues[property] : null,
                newValue = entry.State != EntityState.Deleted ? entry.CurrentValues[property] : null
            });
        }

        return JsonSerializer.Serialize(new
        {
            operation,
            changes
        }, new JsonSerializerOptions 
        {
            WriteIndented = false,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        });
    }
}