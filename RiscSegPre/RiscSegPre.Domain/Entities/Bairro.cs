using System;
using System.Collections.Generic;

namespace RiscSegPre.Domain.Entities
{
    public partial class Bairro
    {
        protected Bairro()
        {
            Inspecao = new HashSet<Inspecao>();
        }

        public Bairro(int id_bairro, string nm_bairro, string cidade, string estado, string cisp, string risp, string aisp, string ocorrencias, DateTime? dt_atualizacao, DateTime dt_cadastro, int id_delegacia, int id_batalhao, int id_risco)
        {
            this.id_bairro = id_bairro;
            this.nm_bairro = nm_bairro;
            this.cidade = cidade;
            this.estado = estado;
            this.cisp = cisp;
            this.risp = risp;
            this.aisp = aisp;
            this.ocorrencias = ocorrencias;
            this.dt_atualizacao = dt_atualizacao;
            this.dt_cadastro = dt_cadastro;
            this.id_delegacia = id_delegacia;
            this.id_batalhao = id_batalhao;
            this.id_risco = id_risco;
        }

        public int id_bairro { get; private set; }
        public string nm_bairro { get; private set; }
        public string cidade { get; private set; }
        public string estado { get; private set; }
        public string cisp { get; private set; }
        public string risp { get; private set; }
        public string aisp { get; private set; }
        public string ocorrencias { get; private set; }
        public DateTime? dt_atualizacao { get; private set; }
        public DateTime dt_cadastro { get; private set; }
        public int id_delegacia { get; private set; }
        public int id_batalhao { get; private set; }
        public int id_risco { get; private set; }
        public virtual BatalhaoPoliciaMilitar id_batalhaoNavigation { get; private set; }
        public virtual DelegaciaPoliciaCivil id_delegaciaNavigation { get; private set; }
        public virtual Risco id_riscoNavigation { get; private set; }
        public virtual ICollection<Inspecao> Inspecao { get; private set; }
    }
}
