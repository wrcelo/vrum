using System.Security.Claims;
using Wrcelo.VrumApp.Core.DTO;

namespace Wrcelo.VrumApp.Domain.Service
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(string email, string password);
        Task RegisterAsync(UserDTO userDto, ClaimsPrincipal loggedUser);
    }
}
