using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string? BookName { get; set; }
        public string? BookDescription { get; set; }
        public string? AuthorName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
    }
}
