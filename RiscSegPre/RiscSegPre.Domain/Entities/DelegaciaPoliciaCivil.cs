using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities
{
    public partial class DelegaciaPoliciaCivil : Endereco
    {
        protected DelegaciaPoliciaCivil()
        {
            Bairro = new HashSet<Local>();
        }

        public DelegaciaPoliciaCivil(int id_delegacia, string ds_delegacia)
        {
            this.id_delegacia = id_delegacia;
            this.ds_delegacia = ds_delegacia;
        }

        public int id_delegacia { get; private set; }
        public string ds_delegacia { get; private set; }
        public virtual ICollection<Local> Bairro { get; private set; }
    }
}
