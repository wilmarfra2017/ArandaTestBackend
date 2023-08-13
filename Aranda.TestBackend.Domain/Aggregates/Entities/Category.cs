using System.ComponentModel.DataAnnotations;

namespace Aranda.TestBackend.Domain.Aggregates.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        
    }
}
