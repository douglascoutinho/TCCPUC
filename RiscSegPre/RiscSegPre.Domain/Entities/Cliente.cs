using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Inspecao = new HashSet<Inspecao>();
        }

        public Cliente(int id_cliente, string nm_cliente)
        {
            this.id_cliente = id_cliente;
            this.nm_cliente = nm_cliente;

        }

        public int id_cliente { get; private set; }
        public string nm_cliente { get; private set; }

        public virtual ICollection<Inspecao> Inspecao { get; private set; }
    }
}
