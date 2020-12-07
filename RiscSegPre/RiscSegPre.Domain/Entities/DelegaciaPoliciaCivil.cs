using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Domain.Entities
{
    public partial class DelegaciaPoliciaCivil : Endereco
    {
        public DelegaciaPoliciaCivil()
        {
            Bairro = new HashSet<Bairro>();
        }

        [Key]
        public int id_delegacia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Nome")]
        public string ds_delegacia { get; set; }

        public virtual ICollection<Bairro> Bairro { get; set; }
    }
}
