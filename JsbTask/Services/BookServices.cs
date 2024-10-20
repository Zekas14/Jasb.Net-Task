using Core.DTO;
using Core.Entities;
using Core.Interfaces;
using Infrastrucutre.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JsbTask.Services
{
    public class BookServices(LibraryContext context) : IBookServices
    {
        private readonly LibraryContext context= context;
        public bool CheckBook(int id)
        {
            return context.Books.Any(b=>b.BookId == id);
        }
        public async Task AddBook(BookDataDto dto)
        {
            try
            { 
                var book = new Book()
                    {
                        Name = dto.Name,
                        Author = dto.Author,
                        CategoryId = dto.CategoryId,
                        Description = dto.Description,
                        Price = dto.Price,
                        Stock = dto.Stock,
                    };
                    await context.Books.AddAsync(book);
                    await context.SaveChangesAsync();
                
            }
            catch 
            {
                throw;   
            }
        }

        public async Task DeleteBook(int id)
        {
            try
            {
                await context.Books.Where(b => b.BookId == id).ExecuteDeleteAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<GetBookDto>> GetAllBooks()
        {
            try
            {
               List<GetBookDto> books =new List<GetBookDto>();
                foreach (var item in await context.Books.Include(b=>b.Category).AsNoTracking().ToListAsync())
                {
                    var book = new GetBookDto()
                    {
                        Id = item.BookId,
                        BookName = item.Name!,
                        Price = item.Price,
                        AuthorName = item.Author!,
                        BookDescription = item.Description!,
                        Stock = item.Stock,
                        Category = item.Category!.Name,

                    };
                    books.Add(book);
                }
                return books;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<GetBookDto?> GetBookById(int id)
        {
            try
            {
                if (CheckBook(id))
                {
                    var book= await context.Books.Include(b=>b.Category).FirstOrDefaultAsync(b=>b.BookId==id);
                    GetBookDto dto = new()
                    {
                        Id =book!.BookId,
                        BookName = book.Name!,
                        Price = book.Price,
                        AuthorName = book.Author!,
                        BookDescription = book.Description!,
                        Stock = book.Stock,
                        Category = book.Category!.Name,
                    };
                    return dto;
                }
                return null;
            }catch(Exception)
            {
                throw;
            }
        }

        public async Task UpdateBook(int id, BookDataDto dto)
        {
            try 
            {
                var book = await context.Books.FindAsync(id);
                
                    book!.Name = dto.Name;
                    book.Price = dto.Price;
                    book.Description = dto.Description;
                    book.Author= dto.Author;
                    book.Stock = dto.Stock;
                    book.CategoryId = dto.CategoryId;
                    await context.SaveChangesAsync();
               }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
