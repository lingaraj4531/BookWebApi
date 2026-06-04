using BookWebApi.Data;
using BookWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BookDbContext _context;

        public AuthRepository(BookDbContext context)
        {
            _context = context;
        }

        // Find user by username from DB
        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                                 .FirstOrDefaultAsync(u => u.UserName == username);
        }

        // Register new user
        public async Task<User> CreateUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}