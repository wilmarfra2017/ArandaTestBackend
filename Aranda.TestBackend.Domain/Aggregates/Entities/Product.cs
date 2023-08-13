using System.ComponentModel.DataAnnotations;

namespace Aranda.TestBackend.Domain.Aggregates.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameProduct { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        
        public Category? Category { get; set; }
    }
}
