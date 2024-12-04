using backend.AppDbContext;
using backend.DTOS;
using backend.Repositories.Interface;
using backend.Services;
using backend.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        public ActionResult Login(LoginDto login)
        {
            var token = _tokenService.GerarToken(login);
            if (token == "")
                return Unauthorized();
            return Ok(new { token });
        }
    }
}
