using backend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace backend.DTOS
{
    public class PetUpdateDTO : DataHoraCriacaoAtualizacao
    {
        public string DonoEndereco { get; set; }

        public string? DonoNumeroEndereco { get; set; }

        public string? DonoComplemento { get; set; }
        public string DonoTelefone { get; set; }

        [DefaultValue(false)]
        public bool Inativo { get; set; }
        public string DonoNome { get; set; }
        public string PetNome { get; set; }
        public string PetSexo { get; set; }
        public DateTime? PetNascimento { get; set; }

        public int RacaId { get; set; }
        public Raca? Raca { get; set; }

        [Column(TypeName = "jsonb")]
        public string? Doencas { get; set; }

        [Column(TypeName = "jsonb")]
        public string? Fraturas { get; set; }

        [Column(TypeName = "jsonb")]
        public string? Medos { get; set; }


        [DefaultValue(false)]
        public bool Gestante { get; set; }
    }
}
