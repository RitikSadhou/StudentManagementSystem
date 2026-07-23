using StudentManagementSystem.DTOs;
using StudentManagementSystem.Helpers;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtTokenGenerator _jwt;

        public AuthService(  IUserRepository userRepository,JwtTokenGenerator jwt)
        {
            _userRepository = userRepository;
            _jwt = jwt;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            var user = await _userRepository.GetByUsernameAsync(dto.Username);

            if (user != null)
                return false;

            var newUser = new User
            {
                Username = dto.Username,
                PasswordHash = PasswordHasher.Hash(dto.Password)
            };

            await _userRepository.AddUserAsync(newUser);

            return true;
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByUsernameAsync(dto.Username);

            if (user == null)
                return null;

            if (user.PasswordHash != PasswordHasher.Hash(dto.Password))
                return null;

            return _jwt.GenerateToken(user.Username);
        }
    }
}
