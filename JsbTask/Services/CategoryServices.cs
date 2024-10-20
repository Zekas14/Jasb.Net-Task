using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Infrastrucutre.Data;
using Microsoft.EntityFrameworkCore;

namespace JsbTask.Services
{
    public class CategoryServices(LibraryContext context) : ICategoryServices
    {
        private readonly LibraryContext context = context;
        public bool CheckCategory(int id)
        {
            return context.Categories.Any(c=>c.CategoryId==id);
        }
        public async Task AddCategory(CategoryDataDto dto)
        {
            try
            {
                var category = new Category()
                {
                    Name = dto.Name,
                    Description = dto.Description
                };
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

       

        public async Task DeleteCategory(int id)
        {
            try
            {
                await context.Categories.Where(b => b.CategoryId== id).ExecuteDeleteAsync();
            }
            catch
            {
                throw;
            }

        }

        public async Task<List<GetCategoryDto>> GetAllCategories()
        {
            try
            {
                List<GetCategoryDto> categories = new();
                foreach (var item in await context.Categories.AsNoTracking().ToListAsync())
                {
                    var category = new GetCategoryDto()
                    {
                        Id = item.CategoryId,
                        Name = item.Name!,
                        Description = item.Description!,

                    };
                    categories.Add(category);
                }
                return categories;
            }
            catch
            {
                throw;
            }
        }

        public async Task<GetCategoryDto?> GetCategoryById(int id)
        {
            try
            {
                if (CheckCategory(id))
                {
                    var category = await context.Categories.FindAsync(id);
                    GetCategoryDto dto = new()
                    {
                        Id = category!.CategoryId,
                        Name = category.Name!,
                        Description= category.Description!
                    };
                    return dto;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateCategory(int id, CategoryDataDto dto)   
        {
            try
            {
                var category = await context.Categories.FindAsync(id);
                category!.Name = dto.Name;
                category.Description = dto.Description;
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
