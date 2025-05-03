using DL.Core.Extensions;
using DL.Core.Models.Product;
using DL.Directories.Dtos;
using DL.Directories.Interfaces.ProductInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DL.Directories.Controllers;

/// <summary>
/// Контроллер наименований товаров
/// </summary>
[Authorize]
[ApiController]
[Route("[controller]")]
public class ProductNameController : ControllerBase
{
    private readonly IProductNameService _productNameService;

    public ProductNameController(IProductNameService productNameService)
    {
        _productNameService = productNameService;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var productNames = await _productNameService.ListAsync();

        return Ok(productNames);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var productName = await _productNameService.GetAsync(id);

            return Ok(productName);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductName productName)
    {
        var userId = HttpContext.User.GetUserId();
        productName.CreatedBy = userId;

        var result = await _productNameService.CreateAsync(productName);

        return Ok(new { result.Id });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ProductName productName)
    {
        var userId = HttpContext.User.GetUserId();
        productName.UpdatedBy = userId;
        
        if (id != productName.Id)
        {
            return BadRequest("ID mismatch.");
        }

        try
        {
            var result = await _productNameService.UpdateAsync(productName);

            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var result = await _productNameService.DeleteAsync(id);

            return result ? Ok() : NotFound();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpGet("for-audit/{id:int}")]
    public async Task<IActionResult> GetForAudit(int id)
    {
        try
        {
            var productName = await _productNameService.GetForAuditAsync(id);

            return Ok(productName);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}