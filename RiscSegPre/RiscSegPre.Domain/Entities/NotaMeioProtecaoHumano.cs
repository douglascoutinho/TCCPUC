using RiscSegPre.Domain.Entities.Factory;
using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities
{
    public partial class NotaMeioProtecaoHumano : INota
    {
        protected NotaMeioProtecaoHumano()
        {
            Inspecao = new HashSet<Inspecao>();
        }

        public NotaMeioProtecaoHumano(int id_notaMeioProtecaoHumano, int guardaSeguranca, int gestaoServicoVigilancia, int equipamentoMaterial, int capacidadeOperacional)
        {
            this.id_notaMeioProtecaoHumano = id_notaMeioProtecaoHumano;
            this.guardaSeguranca = guardaSeguranca;
            this.gestaoServicoVigilancia = gestaoServicoVigilancia;
            this.equipamentoMaterial = equipamentoMaterial;
            this.capacidadeOperacional = capacidadeOperacional;
        }

        public int id_notaMeioProtecaoHumano { get; private set; }
        public int guardaSeguranca { get; private set; }
        public int gestaoServicoVigilancia { get; private set; }
        public int equipamentoMaterial { get; private set; }
        public int capacidadeOperacional { get; private set; }

        public virtual ICollection<Inspecao> Inspecao { get; private set; }

        public decimal CalcularMedia(Inspecao inspecao)
        {
            var mediaProtecaoHumano = ((inspecao.id_notaMeioProtecaoHumanoNavigation.guardaSeguranca +
                                        inspecao.id_notaMeioProtecaoHumanoNavigation.gestaoServicoVigilancia +
                                        inspecao.id_notaMeioProtecaoHumanoNavigation.equipamentoMaterial +
                                        inspecao.id_notaMeioProtecaoHumanoNavigation.capacidadeOperacional) / 4);
            return mediaProtecaoHumano;
        }

        public decimal MontarNota(Inspecao inspecao)
        {
            var mediaProtecaoHumano = ((inspecao.id_notaMeioProtecaoHumanoNavigation.guardaSeguranca +
                                       inspecao.id_notaMeioProtecaoHumanoNavigation.gestaoServicoVigilancia +
                                       inspecao.id_notaMeioProtecaoHumanoNavigation.equipamentoMaterial +
                                       inspecao.id_notaMeioProtecaoHumanoNavigation.capacidadeOperacional) / 4);
            return mediaProtecaoHumano;
        }
    }
}
