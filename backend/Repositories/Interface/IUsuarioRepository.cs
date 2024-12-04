using backend.Models;

namespace backend.Repositories.Interface
{
    public interface IUsuarioRepository
    {
        Usuario GetByEmail(string email);
    }
}
