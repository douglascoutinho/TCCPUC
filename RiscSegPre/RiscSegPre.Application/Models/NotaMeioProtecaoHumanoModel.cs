using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Application.Models
{
    public class NotaMeioProtecaoHumanoModel
    {
        public int id_notaMeioProtecaoHumano { get; set; }

        [Display(Name = "Guarda Segurança")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int guardaSeguranca { get; set; }

        [Display(Name = "Getão Vigilancia")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int gestaoServicoVigilancia { get; set; }


        [Display(Name = "Equipamento e Material")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int equipamentoMaterial { get; set; }

        [Display(Name = "Capacidade Operacional")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int capacidadeOperacional { get; set; }
    }
}