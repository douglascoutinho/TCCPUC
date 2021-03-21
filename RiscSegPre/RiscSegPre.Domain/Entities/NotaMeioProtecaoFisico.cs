using RiscSegPre.Domain.Entities.Factory;
using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities
{
    public partial class NotaMeioProtecaoFisico : INota
    {
        protected NotaMeioProtecaoFisico()
        {
            Inspecao = new HashSet<Inspecao>();
        }

        public NotaMeioProtecaoFisico(int id_notaMeioProtecaoFisico, int sistemaDeteccaoIntruso, int recursoSegurancaPerimetroExterno, int meiosDesaceleracaoFrenagemVeiculo, int controleAcessoVeiculo, int controleAcessoPedestre, int meioProtecaoEdificio, int armarioSeguranca)
        {
            this.id_notaMeioProtecaoFisico = id_notaMeioProtecaoFisico;
            this.sistemaDeteccaoIntruso = sistemaDeteccaoIntruso;
            this.recursoSegurancaPerimetroExterno = recursoSegurancaPerimetroExterno;
            this.meiosDesaceleracaoFrenagemVeiculo = meiosDesaceleracaoFrenagemVeiculo;
            this.controleAcessoVeiculo = controleAcessoVeiculo;
            this.controleAcessoPedestre = controleAcessoPedestre;
            this.meioProtecaoEdificio = meioProtecaoEdificio;
            this.armarioSeguranca = armarioSeguranca;
        }

        public int id_notaMeioProtecaoFisico { get; private set; }
        public int sistemaDeteccaoIntruso { get; private set; }
        public int recursoSegurancaPerimetroExterno { get; private set; }
        public int meiosDesaceleracaoFrenagemVeiculo { get; private set; }
        public int controleAcessoVeiculo { get; private set; }
        public int controleAcessoPedestre { get; private set; }
        public int meioProtecaoEdificio { get; private set; }
        public int armarioSeguranca { get; private set; }

        public virtual ICollection<Inspecao> Inspecao { get; private set; }

        public decimal MontarNota(Inspecao inspecao)
        {
            var mediaProtecaoFisico = ((inspecao.id_notaMeioProtecaoFisicoNavigation.sistemaDeteccaoIntruso +
                                       inspecao.id_notaMeioProtecaoFisicoNavigation.recursoSegurancaPerimetroExterno +
                                       inspecao.id_notaMeioProtecaoFisicoNavigation.meiosDesaceleracaoFrenagemVeiculo +
                                       inspecao.id_notaMeioProtecaoFisicoNavigation.controleAcessoVeiculo +
                                       inspecao.id_notaMeioProtecaoFisicoNavigation.controleAcessoPedestre +
                                       inspecao.id_notaMeioProtecaoFisicoNavigation.meioProtecaoEdificio +
                                       inspecao.id_notaMeioProtecaoFisicoNavigation.armarioSeguranca) / 7);
            return mediaProtecaoFisico;
        }
    }
}