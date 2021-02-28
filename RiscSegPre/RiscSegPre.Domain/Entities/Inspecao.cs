using System;

namespace RiscSegPre.Domain.Entities
{
    public partial class Inspecao
    {
        protected Inspecao()
        {

        }

        public Inspecao(int id_inspecao, string distanciaComunidade, string motivoReprovacao, decimal nota, string situacao, string fotoPredio, string fotoApartamento,
                        int id_cliente, int id_predio, int id_apartamento, int id_bairro,
                        int id_notaMeioProtecaoTecnico, int id_notaMeioProtecaoFisico, int id_notaAvaliacaoProcedimento, int id_notaMeioProtecaoHumano,
                        NotaMeioProtecaoFisico id_notaMeioProtecaoFisicoNavigation, NotaMeioProtecaoHumano id_notaMeioProtecaoHumanoNavigation, NotaMeioProtecaoTecnico id_notaMeioProtecaoTecnicoNavigation, NotaAvaliacaoProcedimento id_notaAvaliacaoProcedimentoNavigation)
        {
            this.id_inspecao = id_inspecao;
            this.distanciaComunidade = distanciaComunidade;
            this.motivoReprovacao = motivoReprovacao;
            this.nota = nota;
            this.situacao = situacao;
            this.fotoPredio = fotoPredio;
            this.fotoApartamento = fotoApartamento;

            this.id_cliente = id_cliente;
            this.id_predio = id_predio;
            this.id_apartamento = id_apartamento;
            this.id_bairro = id_bairro;

            this.id_notaMeioProtecaoTecnico = id_notaMeioProtecaoTecnico;
            this.id_notaMeioProtecaoFisico = id_notaMeioProtecaoFisico;
            this.id_notaAvaliacaoProcedimento = id_notaAvaliacaoProcedimento;
            this.id_notaMeioProtecaoHumano = id_notaMeioProtecaoHumano;

            this.id_notaMeioProtecaoFisicoNavigation = id_notaMeioProtecaoFisicoNavigation;
            this.id_notaMeioProtecaoHumanoNavigation = id_notaMeioProtecaoHumanoNavigation;
            this.id_notaMeioProtecaoTecnicoNavigation = id_notaMeioProtecaoTecnicoNavigation;
            this.id_notaAvaliacaoProcedimentoNavigation = id_notaAvaliacaoProcedimentoNavigation;
        }

        public Inspecao(NotaMeioProtecaoFisico id_notaMeioProtecaoFisicoNavigation, NotaMeioProtecaoHumano id_notaMeioProtecaoHumanoNavigation, NotaMeioProtecaoTecnico id_notaMeioProtecaoTecnicoNavigation, NotaAvaliacaoProcedimento id_notaAvaliacaoProcedimentoNavigation)
        {
            this.id_notaMeioProtecaoFisicoNavigation = id_notaMeioProtecaoFisicoNavigation;
            this.id_notaMeioProtecaoHumanoNavigation = id_notaMeioProtecaoHumanoNavigation;
            this.id_notaMeioProtecaoTecnicoNavigation = id_notaMeioProtecaoTecnicoNavigation;
            this.id_notaAvaliacaoProcedimentoNavigation = id_notaAvaliacaoProcedimentoNavigation;
        }

        public int id_inspecao { get; private set; }
        public string distanciaComunidade { get; private set; }
        public string motivoReprovacao { get; private set; }
        public decimal nota { get; private set; }
        public string situacao { get; private set; }
        public string fotoPredio { get; private set; }
        public string fotoApartamento { get; private set; }

        public int id_cliente { get; private set; }
        public int id_predio { get; private set; }
        public int id_apartamento { get; private set; }
        public int id_bairro { get; private set; }

        public int id_notaMeioProtecaoTecnico { get; private set; }
        public int id_notaMeioProtecaoFisico { get; private set; }
        public int id_notaAvaliacaoProcedimento { get; private set; }
        public int id_notaMeioProtecaoHumano { get; private set; }
        public DateTime dt_cadastro { get; private set; }

        public virtual Apartamento id_apartamentoNavigation { get; private set; }
        public virtual Bairro id_bairroNavigation { get; private set; }
        public virtual Cliente id_clienteNavigation { get; private set; }
        public virtual Predio id_predioNavigation { get; private set; }

        public virtual NotaMeioProtecaoFisico id_notaMeioProtecaoFisicoNavigation { get; private set; }
        public virtual NotaMeioProtecaoHumano id_notaMeioProtecaoHumanoNavigation { get; private set; }
        public virtual NotaMeioProtecaoTecnico id_notaMeioProtecaoTecnicoNavigation { get; private set; }
        public virtual NotaAvaliacaoProcedimento id_notaAvaliacaoProcedimentoNavigation { get; private set; }

        internal Inspecao InserirMediaGeral(Inspecao inspecao, decimal media_geral)
        {
            inspecao.nota = media_geral;
            return inspecao;
        }

        internal Inspecao InserirSituacao(Inspecao inspecao, string motivos)
        {

            if (motivos.Length > 0)
            {
                inspecao.situacao = "Reprovada";
                inspecao.motivoReprovacao = motivos;
            }
            else
                inspecao.situacao = "Aprovada";

            return inspecao;
        }
    }
}
