using System.ComponentModel.DataAnnotations;

namespace CRUDApiDotNet.src.DTOs
{
    public class ProductDto
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public float Price { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public class CreateProductDto
    {
        [Required(ErrorMessage = "Title wajib diisi")]
        [MinLength(3, ErrorMessage = "Title minimal 3 karakter")]
        [MaxLength(100, ErrorMessage = "Title tidak boleh melebihi 100 karakter")]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Required(ErrorMessage = "Price wajib diisi")]
        [Range(0, double.MaxValue, ErrorMessage = "Price harus lebih besar dari 0")]
        public float Price { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}