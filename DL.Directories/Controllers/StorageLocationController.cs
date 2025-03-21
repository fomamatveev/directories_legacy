using DL.Core;
using DL.Core.Extensions;
using DL.Core.Models.Storage;
using DL.Directories.Interfaces.StorageInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DL.Directories.Controllers;

/// <summary>
/// Контроллер места хранения
/// </summary>
[Authorize]
[ApiController]
[Route("[controller]")]
public class StorageLocationController : ControllerBase
{
    private readonly IStorageLocationService _storageLocationService;

    public StorageLocationController(IStorageLocationService storageLocationService)
    {
        _storageLocationService = storageLocationService;
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var productsTypes = await _storageLocationService.ListAsync();

        return Ok(productsTypes);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var productType = await _storageLocationService.GetAsync(id);

            return Ok(productType);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(StorageLocation storageLocation)
    {
        var userId = HttpContext.User.GetUserId();
        storageLocation.CreatedBy = userId;
        
        if (storageLocation == null)
        {
            return BadRequest("Product is null");
        }

        var result = await _storageLocationService.CreateAsync(storageLocation);

        return Ok(new { result.Id });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, StorageLocation storageLocation)
    {
        var userId = HttpContext.User.GetUserId();
        storageLocation.UpdatedBy = userId;
        
        if (id != storageLocation.Id)
        {
            return BadRequest("ID mismatch.");
        }

        try
        {
            var result = await _storageLocationService.UpdateAsync(storageLocation);

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
            var result = await _storageLocationService.DeleteAsync(id);

            return result ? Ok() : NotFound();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}