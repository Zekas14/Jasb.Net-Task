using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class BookDataDto
    {
        [Required]
        [MaxLength(50)]
            [MinLength(4)]
            public string? Name { get; set; }
            [Required]
            [MinLength(4)]
            [MaxLength(50)]
            public string? Author { get; set; }
            [Required]
            [MinLength(4)]
            [MaxLength(200)]
            public string? Description { get; set; }
            [DefaultValue(0)]
        [Range(0, double.MaxValue,ErrorMessage ="Price Cannot Be Negative")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Stock Cannot Be Negative")]
        [DefaultValue(0)]
        public int Stock { get; set; }
        public int CategoryId { get; set; }

    }
}
