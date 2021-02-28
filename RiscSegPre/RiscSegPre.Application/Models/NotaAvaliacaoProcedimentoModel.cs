using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Application.Models
{
    public class NotaAvaliacaoProcedimentoModel
    {
        public int id_notaAvaliacaoProcedimento { get; set; }

        [Display(Name = "Local Específico")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int especificosLocal { get; set; }

        [Display(Name = "Organização e Segurança")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int organizacaoSeguranca { get; set; }

        [Display(Name = "Treinamento Segurança")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int treinamentoConscientizacaoSeguranca { get; set; }

        [Display(Name = "Segurança Emergencial")]
        [Range(typeof(int), "0", "100", ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
        public int segurancaEmergenciaExpatriados { get; set; }
    }
}