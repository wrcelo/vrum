using System.Security.Claims;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Domain.Service;

namespace Wrcelo.VrumApp.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<string> AuthenticateAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                throw new Exception("Credenciais inválidas.");

            return _tokenService.GenerateToken(user);
        }

        public async Task RegisterAsync(UserDTO userDto)
        {
            try
            {
                var user = new User
                {
                    Guid = Guid.NewGuid(),
                    Email = userDto.Email,
                    Name = userDto.Name,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                    Role = userDto.Role
                };

                await _userRepository.AddAsync(user);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
