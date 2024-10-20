using Azure.Core;
using Core.DTO;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsbTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IBookServices bookServices, ICategoryServices categoryServices) : ControllerBase
    {
        private readonly IBookServices bookServices = bookServices;
        private readonly ICategoryServices categoryServices = categoryServices;


        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok( await bookServices.GetAllBooks());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var book = await bookServices.GetBookById(id);
            if(book is not null)
            {
                return Ok(book);
            }
            return NotFound("Book Not Found");
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookDataDto dto)
        {
            if (!categoryServices.CheckCategory(dto.CategoryId))
            {
                ModelState.AddModelError("Category", $"Category With {dto.CategoryId} Id Not Found");
            }

            if (ModelState.IsValid)
            {
                await bookServices.AddBook(dto);
                var baseUrl = $"{Request.Scheme}://{Request.Host.Value}{Request.PathBase.Value}";
                return Created(baseUrl, "Book Added Sucessfully");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            if (!bookServices.CheckBook(id))
            {
                return NotFound("Book Not Found");
            }
            if (ModelState.IsValid)
            {
                await bookServices.DeleteBook(id);
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, BookDataDto dto)
        {
            if (!bookServices.CheckBook(id))
            {
               return NotFound("Book Not Found");

            }
            if (!categoryServices.CheckCategory(dto.CategoryId))
            {
                return NotFound("Category Not Found");
            }

            if (ModelState.IsValid)
            {
                await bookServices.UpdateBook(id, dto);
                return NoContent();
            }
            return BadRequest(ModelState);
        }
    }
}
