using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Domain.Entities
{
    public partial class BatalhaoPoliciaMilitar : Endereco
    {
        public BatalhaoPoliciaMilitar()
        {
            Bairro = new HashSet<Bairro>();
        }

        [Key]
        public int id_batalhao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Nome")]
        public string ds_delegacia { get; set; }
        public virtual ICollection<Bairro> Bairro { get; set; }
    }
}
