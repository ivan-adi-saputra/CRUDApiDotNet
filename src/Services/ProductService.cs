using CRUDApiDotNet.src.Database;
using CRUDApiDotNet.src.DTOs;
using CRUDApiDotNet.src.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDApiDotNet.src.Services
{
    public class ProductService: IProductServices
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            return await _context.Products
                .Select(p => new ProductDto {
                    Title = p.Title,
                    Description = p.Description,
                    Price = p.Price,
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt
                }).ToListAsync();
        }

        public async Task<ProductDto?> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            return new ProductDto
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt
            };
        }

        public async Task<ProductDto> CreateProduct(CreateProductDto createDto)
        {
            var product = new Product
            {
                Title = createDto.Title,
                Description = createDto.Description,
                Price = createDto.Price,
                IsActive = createDto.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt
            };
        }

        public async Task<ProductDto?> UpdateProduct(int id, CreateProductDto updateDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            product.Title = updateDto.Title;
            product.Description = updateDto.Description;
            product.Price = updateDto.Price;
            product.IsActive = updateDto.IsActive;

            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                IsActive = product.IsActive,
                CreatedAt = product.CreatedAt
            };
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}