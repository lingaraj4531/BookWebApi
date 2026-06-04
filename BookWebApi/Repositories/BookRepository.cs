using BookWebApi.Data;
using BookWebApi.Models;
using BookWebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookWebApi.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetStudentAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetStudentByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> CreateStudentAsync(Book book)
        {
            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> UpdateStudentAsync(Book book)
        {
            _context.Books.Update(book);

            await _context.SaveChangesAsync();
            return book;
        }

        public async Task DeleteStudentAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                _context.Books.Remove(book);

                await _context.SaveChangesAsync();
            }
        }
    }
}
