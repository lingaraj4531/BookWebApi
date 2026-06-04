using BookWebApi.Models;
using BookWebApi.Repositories;

namespace BookWebApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        private readonly TokenService _tokenService;

        public AuthService(IAuthRepository repo, TokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        // Login
        public async Task<string?> LoginAsync(LoginRequest request)
        {
            // Step 1: Find user in DB
            var user = await _repo.GetUserByUsernameAsync(request.UserName);

            // Step 2: User not found
            if (user == null)
                return null;

            // Step 3: Check password
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);
            if (!isPasswordValid)
                return null;

            // Step 4: Generate and return token
            return _tokenService.GenerateToken(user);
        }

        // Register
        public async Task<User> RegisterAsync(LoginRequest request)
        {
            var user = new User
            {
                UserName = request.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password), // 🔒 hash password
                Role = "User" // default role
            };

            return await _repo.CreateUserAsync(user);
        }
    }
}