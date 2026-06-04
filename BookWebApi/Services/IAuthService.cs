using BookWebApi.Models;

namespace BookWebApi.Services
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginRequest request);
        Task<User> RegisterAsync(LoginRequest request);
    }
}