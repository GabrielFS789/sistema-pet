namespace backend.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Inativo { get; set; }
        public int PermissaoId { get; set; }
        public Permissao? Permissao { get; set; }
        public DateTime DataHoraCadastro { get; private set; }
        public DateTime? DataHoraUltimaAtualizacao { get; private set; }
        public bool Administrador { get; set; }

        public void InsertDataHoraCadastro()
        {
            this.DataHoraCadastro = DateTime.UtcNow;
        }
        public void UpdateDataHoraUltimaAtualizacao()
        {
            this.DataHoraUltimaAtualizacao = DateTime.UtcNow;
        }
    }
}
