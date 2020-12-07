using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;

namespace RiscSegPre.Infra.Data.Repositories
{
    public class RiscoRepository
            : BaseRepository<Risco>, IRiscoRepository
    {
        private readonly DataContext context;

        public RiscoRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}