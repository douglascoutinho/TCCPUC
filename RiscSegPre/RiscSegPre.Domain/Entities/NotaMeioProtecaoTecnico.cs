using RiscSegPre.Domain.IEntities;
using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities
{
    public partial class NotaMeioProtecaoTecnico : ICalcularMedia
    {
        protected NotaMeioProtecaoTecnico()
        {
            Inspecao = new HashSet<Inspecao>();
        }

        public NotaMeioProtecaoTecnico(int id_notaMeioProtecaoTecnico, int sistemaDeteccaoIntruso, int sistemaAlarmeIntruso, int circuitoFechadoVideo, int sistemaControleAcesso, int sistemaComunicacao, int sistemaControleRodizio, int telemonitoramento)
        {
            this.id_notaMeioProtecaoTecnico = id_notaMeioProtecaoTecnico;
            this.sistemaDeteccaoIntruso = sistemaDeteccaoIntruso;
            this.sistemaAlarmeIntruso = sistemaAlarmeIntruso;
            this.circuitoFechadoVideo = circuitoFechadoVideo;
            this.sistemaControleAcesso = sistemaControleAcesso;
            this.sistemaComunicacao = sistemaComunicacao;
            this.sistemaControleRodizio = sistemaControleRodizio;
            this.telemonitoramento = telemonitoramento;
        }

        public int id_notaMeioProtecaoTecnico { get; private set; }
        public int sistemaDeteccaoIntruso { get; private set; }
        public int sistemaAlarmeIntruso { get; private set; }
        public int circuitoFechadoVideo { get; private set; }
        public int sistemaControleAcesso { get; private set; }
        public int sistemaComunicacao { get; private set; }
        public int sistemaControleRodizio { get; private set; }
        public int telemonitoramento { get; private set; }

        public virtual ICollection<Inspecao> Inspecao { get; private set; }

        public decimal CalcularMedia(Inspecao inspecao)
        {
            var mediaProtecaoTecnico = ((inspecao.id_notaMeioProtecaoTecnicoNavigation.sistemaDeteccaoIntruso +
                                         inspecao.id_notaMeioProtecaoTecnicoNavigation.sistemaAlarmeIntruso +
                                         inspecao.id_notaMeioProtecaoTecnicoNavigation.circuitoFechadoVideo +
                                         inspecao.id_notaMeioProtecaoTecnicoNavigation.sistemaControleAcesso +
                                         inspecao.id_notaMeioProtecaoTecnicoNavigation.sistemaComunicacao +
                                         inspecao.id_notaMeioProtecaoTecnicoNavigation.sistemaControleRodizio +
                                         inspecao.id_notaMeioProtecaoTecnicoNavigation.telemonitoramento) / 7);
            return mediaProtecaoTecnico;
        }
    }
}
