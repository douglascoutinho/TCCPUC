using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Domain.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Inspecao = new HashSet<Inspecao>();
        }

        [Display(Name = "Código")]
        public int id_cliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Nome")]
        public string nm_cliente { get; set; }

        public virtual ICollection<Inspecao> Inspecao { get; set; }
    }
}
