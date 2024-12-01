using DL.Directories.Interfaces.ProductInterface;
using DL.Directories.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace DL.Directories.Controllers;

/// <summary>
/// Контроллер категории товаров
/// </summary>
[ApiController]
[Route("[controller]")]
public class ProductTypeController : ControllerBase
{
    private readonly IProductTypeService _productTypeService;

    public ProductTypeController(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var productsTypes = await _productTypeService.ListAsync();

        return Ok(productsTypes);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var productType = await _productTypeService.GetAsync(id);

            return Ok(productType);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductType productType)
    {
        if (productType == null)
        {
            return BadRequest("Product is null");
        }

        var result = await _productTypeService.CreateAsync(productType);

        return Ok(new { result.Id });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ProductType productType)
    {
        if (id != productType.Id)
        {
            return BadRequest("ID mismatch.");
        }

        try
        {
            var result = await _productTypeService.UpdateAsync(productType);

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
            var result = await _productTypeService.DeleteAsync(id);

            return result ? NoContent() : NotFound();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}