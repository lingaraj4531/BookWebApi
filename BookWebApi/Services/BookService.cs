using BookWebApi.Data;
using BookWebApi.Models;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookWebApi.Services
{
    public class BookService:IBookService
    {
        private readonly BookDbContext _context;

        public BookService(BookDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
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
