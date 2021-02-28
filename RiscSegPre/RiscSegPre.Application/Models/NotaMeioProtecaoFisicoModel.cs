using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Application.Models
{
    public class NotaMeioProtecaoFisicoModel
    {
        public int id_notaMeioProtecaoFisico { get; set; }

        [Display(Name = "Detecção de Intruso")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int sistemaDeteccaoIntruso { get; set; }

        [Display(Name = "Perímetro Externo")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int recursoSegurancaPerimetroExterno { get; set; }

        [Display(Name = "Meio Desaceleração Veículo")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int meiosDesaceleracaoFrenagemVeiculo { get; set; }

        [Display(Name = "Controle Acesso Veículo")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int controleAcessoVeiculo { get; set; }

        [Display(Name = "Controle Acesso Pedestre")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int controleAcessoPedestre { get; set; }

        [Display(Name = "Proteção Edifício")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int meioProtecaoEdificio { get; set; }

        [Display(Name = "Armario Segurança")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int armarioSeguranca { get; set; }
    }
}