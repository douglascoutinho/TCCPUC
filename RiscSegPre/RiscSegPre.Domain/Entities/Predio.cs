using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities
{
    public class Predio : Endereco
    {
        protected Predio()
        {
            Apartamento = new HashSet<Apartamento>();
            Inspecao = new HashSet<Inspecao>();
        }

        public Predio(int id_predio, string nm_predio)
        {
            this.id_predio = id_predio;
            this.nm_predio = nm_predio;
        }

        public int id_predio { get;  private set; }
        public string nm_predio { get; private set; }

        public virtual ICollection<Apartamento> Apartamento { get; private set; }
        public virtual ICollection<Inspecao> Inspecao { get; private set; }
    }
}