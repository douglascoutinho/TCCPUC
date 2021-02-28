using RiscSegPre.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Application.Models
{
    public class PredioModel : Endereco
    {
        [Key]
        public int id_predio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Nome")]
        public string nm_predio { get; set; }
    }
}