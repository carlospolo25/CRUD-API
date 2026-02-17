using NewAppi.Aplication.DTOs.Productos;

namespace NewAppi.Aplication.Service
{
    public interface IProductoService
    {
        Task<List<ProductoDto>> GetAllAsync();
        Task<ProductoDto> GetByIdAsync(int id);
        Task<ProductoDto> CreateAsync(CreateProductoDto dto);
        Task<bool> UpdateAsync(int id, UpdateProductoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
