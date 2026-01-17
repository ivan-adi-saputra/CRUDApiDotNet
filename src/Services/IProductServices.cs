
using CRUDApiDotNet.src.DTOs;

namespace CRUDApiDotNet.src.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto?> GetProductById(int id);
        Task<ProductDto> CreateProduct(CreateProductDto createDto);
        Task<ProductDto?> UpdateProduct(int id, CreateProductDto updateDto);
        Task<bool> DeleteProduct(int id);
    }
}