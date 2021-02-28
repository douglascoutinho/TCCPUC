using RiscSegPre.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Application.Models
{
    public class BatalhaoPoliciaMilitarModel : Endereco
    {
        [Key]
        public int id_batalhao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Nome")]
        public string ds_delegacia { get; set; }
    }
}
