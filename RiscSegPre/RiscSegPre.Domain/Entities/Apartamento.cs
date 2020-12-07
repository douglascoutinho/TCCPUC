using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Domain.Entities
{
    public partial class Apartamento
    {
        public Apartamento()
        {
            Inspecao = new HashSet<Inspecao>();
        }

        [Key]
        public int id_apartamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Nome")]
        public string nm_apartamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Número")]
        public string numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Prédio")]
        public int id_predio { get; set; }


        [Display(Name = "Prédio")]
        public virtual Predio id_predioNavigation { get; set; }
        public virtual ICollection<Inspecao> Inspecao { get; set; }
    }
}
