using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities
{
    public partial class Apartamento
    {
        protected Apartamento()
        {
            Inspecao = new HashSet<Inspecao>();
        }

        public Apartamento(int id_apartamento, string nm_apartamento, string numero, int id_predio)
        {
            this.id_apartamento = id_apartamento;
            this.nm_apartamento = nm_apartamento;
            this.numero = numero;
            this.id_predio = id_predio;
        }
        
        public int id_apartamento { get; private set; }
        public string nm_apartamento { get; private set; }
        public string numero { get; private set; }
        public int id_predio { get; private set; }

        public virtual Predio id_predioNavigation { get; private set; }
        public virtual ICollection<Inspecao> Inspecao { get; private set; }
    }
}