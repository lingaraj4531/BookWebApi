using BookWebApi.Data;
using BookWebApi.Models;
using BookWebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookWebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo; // 👈 Inject Repository instead of DbContext

        public BookService(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _repo.GetStudentAllAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _repo.GetStudentByIdAsync(id);
        }

        public async Task<Book?> CreateAsync(Book book)
        {
            return await _repo.CreateStudentAsync(book);
        }

        public async Task<Book> UpdateAsync(int id, Book book)
        {
            var existing = await _repo.GetStudentByIdAsync(id);
            if (existing == null)
                return null;
        

            
            existing.Title = book.Title;
            existing.Description = book.Description;
            existing.Author = book.Author;
            existing.Country = book.Country;

            return await _repo.UpdateStudentAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetStudentByIdAsync(id);
            if (existing == null)
                return false;

            await _repo.DeleteStudentAsync(id);
            return true;
        }
    }
}
