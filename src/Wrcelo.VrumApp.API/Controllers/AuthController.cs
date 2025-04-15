using Microsoft.AspNetCore.Mvc;
using Wrcelo.VrumApp.Core.DTO;
using Wrcelo.VrumApp.Domain.Service;

namespace Wrcelo.VrumApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                var token = await _authService.AuthenticateAsync(loginDto.Email, loginDto.Password);
                return Ok(new { Token = token });

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto)
        {

            await _authService.RegisterAsync(userDto, User);
            return Ok();
        }


    }
}
