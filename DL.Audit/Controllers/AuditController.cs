using DL.Audit.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DL.Audit.Controllers;

/// <summary>
/// Контроллер изменений
/// </summary>
[Authorize]
[ApiController]
[Route("[controller]")]
public class AuditController : ControllerBase
{
    private readonly IAuditService _auditService;

    public AuditController(IAuditService auditService)
    {
        _auditService = auditService;
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var actions = await _auditService.ListAsync();

        return Ok(actions);
    }
}