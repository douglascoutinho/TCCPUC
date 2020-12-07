using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities
{
    public partial class Risco
    {
        public Risco()
        {
            Bairro = new HashSet<Bairro>();
        }

        public int id_risco { get; set; }
        public string ds_risco { get; set; }

        public virtual ICollection<Bairro> Bairro { get; set; }
    }
}
