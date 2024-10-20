using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string? Name { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(200)]
        public string? Description { get; set; }
        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }
        
        public string? Author { get; set; }
        [Range(0,int.MaxValue)]
        public int Stock { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
