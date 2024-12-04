using backend.AppDbContext;
using backend.Models;
using backend.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Usuario GetByEmail(string email)
        {
            var usuario = _context.Usuario.Include(u => u.Permissao).FirstOrDefault(u => u.Email == email);
            return usuario;
        }
    }
}
