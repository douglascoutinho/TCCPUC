using RiscSegPre.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Application.Models
{
    public class DelegaciaPoliciaCivilModel : Endereco
    {
        [Key]
        public int id_delegacia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Nome")]
        public string ds_delegacia { get; set; }
    }
}
