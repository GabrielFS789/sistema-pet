namespace backend.Repositories.Interface
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }

        void Commit();
        void Dispose();

    }
}
