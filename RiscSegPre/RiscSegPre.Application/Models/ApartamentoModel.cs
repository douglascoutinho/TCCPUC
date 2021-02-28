using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Application.Models
{
    public class ApartamentoModel
    {
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
        public PredioModel id_predioNavigation { get;  set; }

    }
}
