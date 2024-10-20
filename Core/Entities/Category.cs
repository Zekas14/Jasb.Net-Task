using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string? Name { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(200)]
        public string? Description { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
