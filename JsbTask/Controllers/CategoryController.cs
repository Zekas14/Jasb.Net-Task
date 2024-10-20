using Core.DTO;
using Core.Interfaces;
using JsbTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsbTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryServices categoryServices) : ControllerBase
    {

        private readonly ICategoryServices categoryServices = categoryServices;


        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await categoryServices.GetAllCategories());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var Category = await categoryServices.GetCategoryById(id);
            if (Category is not null)
            {
                return Ok(Category);
            }
            return NotFound("Catgory Not Found");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDataDto dto)
        {
           

            if (ModelState.IsValid)
            {
                await categoryServices.AddCategory(dto);
                var baseUrl = $"{Request.Scheme}://{Request.Host.Value}{Request.PathBase.Value}";
                return Created(baseUrl, "Category Added Sucessfully");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            if (!categoryServices.CheckCategory(id))
            {
                return NotFound("Category Not Found");
            }
            if (ModelState.IsValid)
            {
                await categoryServices.DeleteCategory(id);
                return NoContent();
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDataDto dto)
        {
            if (!categoryServices.CheckCategory(id))
            {
                return NotFound("Category Not Found");
            }

            if (ModelState.IsValid)
            {
                await categoryServices.UpdateCategory(id, dto);
                return NoContent();
            }
            return BadRequest(ModelState);
        }
    }
}
