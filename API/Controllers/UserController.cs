using API.Contracts;
using API.Data;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public sealed class UserController(IAuthService authService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request) 
            => await authService.Register(request) 
            ? Ok() : BadRequest();

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await authService.Login(request);

            if (response == null) return BadRequest(request);

            return Ok(response);
        }
    }
}
