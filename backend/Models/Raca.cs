using System.ComponentModel;

namespace backend.Models
{
    public class Raca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [DefaultValue(false)]
        public bool Inativo { get; set; }
        public DateTime DataHoraCadastro { get; private set; }
        public DateTime? DataHoraUltimaAtualizacao { get; private set; }

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
