using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Application.Models
{
    public class NotaMeioProtecaoTecnicoModel
    {
        public int id_notaMeioProtecaoTecnico { get; set; }

        [Display(Name = "Sistema Detecção Intruso")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int sistemaDeteccaoIntruso { get; set; }

        [Display(Name = "Sistema Alarme Intruso")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int sistemaAlarmeIntruso { get; set; }

        [Display(Name = "Circuito Fechado de Video")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int circuitoFechadoVideo { get; set; }

        [Display(Name = "Controle de Acesso")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int sistemaControleAcesso { get; set; }

        [Display(Name = "Controle de Comunicação")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int sistemaComunicacao { get; set; }

        [Display(Name = "Sistema Controle Rodizio")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int sistemaControleRodizio { get; set; }

        [Display(Name = "Telemonitoramento")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int telemonitoramento { get; set; }
    }
}