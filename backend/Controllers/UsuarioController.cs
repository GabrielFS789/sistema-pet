using backend.AppDbContext;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Usuario>> GetByEmailAsync(string email)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.Email == email);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(Usuario usuario)
        {
            var password = Criptografia.Criptografa(usuario.Password);
            usuario.InsertDataHoraCadastro();
            usuario.Password = password;
            Console.Write(password);
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }
    }
}
