using Microsoft.EntityFrameworkCore;
using NewAppi.Aplication.DTOs.Productos;
using NewAppi.Domain.Entities;
using NewAppi.Infrastructure.Data;

namespace NewAppi.Aplication.Service;

public class ProductoService : IProductoService
{
    private readonly AppDbContext _context;

    public ProductoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductoDto>> GetAllAsync()
    {
        return await _context.Productos
            .Select(p => new ProductoDto
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock
            }
            )
            .ToListAsync();

    }

    public async Task<ProductoDto?> GetByIdAsync(int  id)
    {
        return await _context.Productos
            .Where(p => p.Id == id)
            .Select(p => new ProductoDto
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock
            })
            .FirstOrDefaultAsync();
    }

    public async Task<ProductoDto> CreateAsync(CreateProductoDto dto)
    {
        var producto = new Productos
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Stock = dto.Stock
        };

        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        return new ProductoDto
        {
            Id = producto.Id,
            Name = producto.Name,
            Description = producto.Description,
            Price = producto.Price,
            Stock = producto.Stock
        };
    }



    public async Task<bool> UpdateAsync(int id, UpdateProductoDto dto)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null) return false;

        producto.Name = dto.Name;
        producto.Description = dto.Description;
        producto.Price = dto.Price;
        producto.Stock = dto.Stock;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync (int id)
    {
        var producto = await _context.Productos.FindAsync (id);

        if (producto == null) 
            return false; 

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();

        return true;
    }
}

