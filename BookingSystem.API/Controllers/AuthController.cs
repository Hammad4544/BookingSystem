using BookingSystem.Application.DTOS.AuthDTOS;
using BookingSystem.Application.InterfaceService;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authservice;

        public AuthController(IAuthService authService)
        {
            _authservice = authService;

        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                var token = await _authservice.Login(dto);
                return Ok(token);
            }
            catch { return BadRequest("Invalid email or password"); }
        }
    }
}
