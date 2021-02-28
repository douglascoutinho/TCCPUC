using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Application.Models
{
    public class ClienteModel
    {
        [Display(Name = "Código")]
        public int id_cliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Nome")]
        public string nm_cliente { get; set; }
    }
}
