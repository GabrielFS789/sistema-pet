using System.Runtime.CompilerServices;

namespace backend.Models
{
    public abstract class DataHoraCriacaoAtualizacao
    {
        public DateTime DataHoraCadastro { get; private set; }
        public DateTime? DataHoraUltimaAtualizacao { get; private set; }

        public void AdicionaDataHoraCadastro()
        {
            DataHoraCadastro = DateTime.UtcNow;
        }

        public void AtualizaDataHoraUltimaAtualizacao()
        {
            DataHoraUltimaAtualizacao = DateTime.UtcNow;
        }

    }
}
