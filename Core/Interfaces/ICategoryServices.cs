using Core.DTO;

namespace Core.Interfaces
{
    public interface ICategoryServices
    {
        Task<List<GetCategoryDto>> GetAllCategories();
        Task<GetCategoryDto?> GetCategoryById(int id);
        Task AddCategory(CategoryDataDto dto);
        Task DeleteCategory(int id);
        Task UpdateCategory(int id, CategoryDataDto dto);
        bool CheckCategory(int id);
    }
}
