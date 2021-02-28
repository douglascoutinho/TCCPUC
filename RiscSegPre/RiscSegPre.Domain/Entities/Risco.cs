using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities
{
    public partial class Risco
    {
        protected Risco()
        {
            Bairro = new HashSet<Bairro>();
        }

        public Risco(int id_risco, string ds_risco)
        {
            this.id_risco = id_risco;
            this.ds_risco = ds_risco;
        }

        public int id_risco { get; private set; }
        public string ds_risco { get; private set; }

        public virtual ICollection<Bairro> Bairro { get; private set; }
    }
}
