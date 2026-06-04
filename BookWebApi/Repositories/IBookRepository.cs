using BookWebApi.Models;

namespace BookWebApi.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetStudentAllAsync();
        Task<Book> GetStudentByIdAsync(int id);
        Task<Book> CreateStudentAsync(Book book);
        Task<Book> UpdateStudentAsync(Book book);
        Task DeleteStudentAsync(int id);

    }
}
