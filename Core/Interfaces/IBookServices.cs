using Core.DTO;

namespace Core.Interfaces
{

    public interface IBookServices
    {
        Task<List<GetBookDto>>  GetAllBooks();
       Task<GetBookDto?> GetBookById(int id);
       Task AddBook(BookDataDto dto);
       Task DeleteBook(int id);
        Task UpdateBook(int id,BookDataDto dto);
        public bool CheckBook(int id);
    }
}
