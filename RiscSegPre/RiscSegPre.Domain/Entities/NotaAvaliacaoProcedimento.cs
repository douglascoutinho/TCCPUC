using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RiscSegPre.Domain.Entities
{
    public partial class NotaAvaliacaoProcedimento
    {
        public NotaAvaliacaoProcedimento()
        {
            Inspecao = new HashSet<Inspecao>();
        }

        public int id_notaAvaliacaoProcedimento { get; set; }

        //[DataType(DataType.Currency)]
        //[Column(TypeName = "decimal(3)")]
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

        public virtual ICollection<Inspecao> Inspecao { get; set; }

        public decimal CalcularMedia(Inspecao inspecao)
        {
            var mediaAvaliacao = ((inspecao.id_notaAvaliacaoProcedimentoNavigation.especificosLocal +
                                   inspecao.id_notaAvaliacaoProcedimentoNavigation.organizacaoSeguranca +
                                   inspecao.id_notaAvaliacaoProcedimentoNavigation.treinamentoConscientizacaoSeguranca +
                                   inspecao.id_notaAvaliacaoProcedimentoNavigation.segurancaEmergenciaExpatriados) / 4);
            return mediaAvaliacao;
        }
    }
}
