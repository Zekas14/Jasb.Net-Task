using System.ComponentModel.DataAnnotations;

namespace Core.DTO
{
    public class CategoryDataDto
    {

        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string? Name { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(200)]
        public string? Description { get; set; }

    }
}
