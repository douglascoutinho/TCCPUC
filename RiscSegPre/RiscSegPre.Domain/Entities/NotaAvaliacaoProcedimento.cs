using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities
{
    public partial class NotaAvaliacaoProcedimento
    {
        protected NotaAvaliacaoProcedimento()
        {
            Inspecao = new HashSet<Inspecao>();
        }

        public NotaAvaliacaoProcedimento(int id_notaAvaliacaoProcedimento, int especificosLocal, int organizacaoSeguranca, int treinamentoConscientizacaoSeguranca, int segurancaEmergenciaExpatriados)
        {
            this.id_notaAvaliacaoProcedimento = id_notaAvaliacaoProcedimento;
            this.especificosLocal = especificosLocal;
            this.organizacaoSeguranca = organizacaoSeguranca;
            this.treinamentoConscientizacaoSeguranca = treinamentoConscientizacaoSeguranca;
            this.segurancaEmergenciaExpatriados = segurancaEmergenciaExpatriados;
        }

        public int id_notaAvaliacaoProcedimento { get; private set; }
        public int especificosLocal { get; private set; }
        public int organizacaoSeguranca { get; private set; }
        public int treinamentoConscientizacaoSeguranca { get; private set; }
        public int segurancaEmergenciaExpatriados { get; private set; }

        public virtual ICollection<Inspecao> Inspecao { get; private set; }

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
