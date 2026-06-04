using BookWebApi.Models;

namespace BookWebApi.Repositories
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User> CreateUserAsync(User user);
    }
}