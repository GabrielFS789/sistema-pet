using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace backend.Models
{
    public class Permissao
    {
        public int Id { get; set; }


        [Required, DefaultValue("Perfil Principal")]
        public string? Nome { get; set; }


        [Required, DefaultValue(true)]
        public bool CriaUsuario { get; set; }


        [Required, DefaultValue(true)]
        public bool AlteraUsuario { get; set; }

        [Required, DefaultValue(true)]
        public bool ExcluirUsuario { get; set; }

        [Required, DefaultValue(true)]
        public bool ListarUsuarios { get; set; }
    }
}
