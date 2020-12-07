using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Domain.Entities
{
    public partial class Endereco
    {
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "CEP")]
        public string cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Logradouro")]
        public string logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Número")]
        public string numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Cidade")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        [Display(Name = "Estado")]
        public string estado { get; set; }
    }
}
