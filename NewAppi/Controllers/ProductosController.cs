using Microsoft.AspNetCore.Mvc;
using NewAppi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NewAppi.Domain.Entities;
using NewAppi.Aplication.DTOs.Productos;
using NewAppi.Aplication.Service;

namespace NewAppi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _service;
    public ProductosController(IProductoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _service.GetAllAsync());


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById ( int id)
    {
       var Producto =await _service.GetByIdAsync(id);   
        if (Producto == null) return NotFound();
        return Ok(Producto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductoDto dto)
    {
        var producto = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = producto.Id },
            producto
        );
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateProductoDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete (int id)
    {
        var delete = await _service.DeleteAsync(id);    
        if (!delete) 
            return NotFound();

        return NoContent();
    }

}