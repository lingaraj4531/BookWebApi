using BookWebApi.Models;

namespace BookWebApi.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> CreateAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);

    }
}
