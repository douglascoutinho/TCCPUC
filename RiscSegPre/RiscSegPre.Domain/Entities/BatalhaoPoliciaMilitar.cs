using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities
{
    public partial class BatalhaoPoliciaMilitar : Endereco
    {
        protected BatalhaoPoliciaMilitar()
        {
            Bairro = new HashSet<Bairro>();
        }

        public BatalhaoPoliciaMilitar(int id_batalhao, string ds_delegacia)
        {
            this.id_batalhao = id_batalhao;
            this.ds_delegacia = ds_delegacia;
        }
        
        public int id_batalhao { get; private set; }
        public string ds_delegacia { get; private set; }
        public virtual ICollection<Bairro> Bairro { get; private set; }
    }
}
