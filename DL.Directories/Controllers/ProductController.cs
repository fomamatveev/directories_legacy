using DL.Core;
using DL.Core.Extensions;
using DL.Directories.Dtos;
using DL.Directories.Interfaces.ProductInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DL.Directories.Controllers;

/// <summary>
/// Контроллер товаров
/// </summary>
[Authorize]
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var products = await _productService.ListAsync();

        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var product = await _productService.GetAsync(id);

            return Ok(product);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto product)
    {
        var userId = HttpContext.User.GetUserId();
        product.CreatedBy = userId;
        
        if (product == null)
        {
            return BadRequest("Product is null");
        }

        var result = await _productService.CreateAsync(product);

        return Ok(new { result.Id });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, ProductDto product)
    {
        var userId = HttpContext.User.GetUserId();
        product.UpdatedBy = userId;
        
        if (id != product.Id)
        {
            return BadRequest("ID mismatch.");
        }

        try
        {
            var result = await _productService.UpdateAsync(product);

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
            var result = await _productService.DeleteAsync(id);

            return result ? Ok() : NotFound();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}