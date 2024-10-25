using SimpleTwitter.DTOs.User;
using SimpleTwitter.Interfaces;
using SimpleTwitter.Models;
using System.Security.Cryptography;
using System.Text;

namespace SimpleTwitter.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            // Check if email is already in use
            if (await _userRepository.GetUserByEmailAsync(registerDto.Email) != null)
                throw new Exception("Email is already in use");

            // Check if username is already in use
            if (await _userRepository.GetUserByUsernameAsync(registerDto.UserName) != null)
                throw new Exception("Username is already in use");

            // Create password hash and salt
            CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // Create a new user
            var user = new User
            {
                UserName = registerDto.UserName,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            // Register the user
            return await _userRepository.RegisterUserAsync(user);
        }

        public async Task<User> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);

            if (user == null || !VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt))
                throw new Exception("Invalid login credentials");

            // Return the full user object (not UserDto) from the service
            return user;
        }


        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHash);
            }
        }
    }
}
