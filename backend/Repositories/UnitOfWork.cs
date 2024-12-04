using backend.AppDbContext;
using backend.Repositories.Interface;

namespace backend.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUsuarioRepository? _usuarioRepo;

        public ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                return _usuarioRepo = _usuarioRepo ?? new UsuarioRepository(_context);
            }
        }

        public async void Commit()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
