using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Domain.Entities
{
    public class Predio : Endereco
    {
        public Predio()
        {
            Apartamento = new HashSet<Apartamento>();
            Inspecao = new HashSet<Inspecao>();
        }

        [Key]
        public int id_predio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Nome")]
        public string nm_predio { get; set; }

        public virtual ICollection<Apartamento> Apartamento { get; set; }
        public virtual ICollection<Inspecao> Inspecao { get; set; }
    }
}