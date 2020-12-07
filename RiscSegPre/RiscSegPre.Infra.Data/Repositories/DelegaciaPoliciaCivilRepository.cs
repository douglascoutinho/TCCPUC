using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;

namespace RiscSegPre.Infra.Data.Repositories
{
    public class DelegaciaPoliciaCivilRepository
            : BaseRepository<DelegaciaPoliciaCivil>, IDelegaciaPoliciaCivilRepository
    {
        private readonly DataContext context;

        public DelegaciaPoliciaCivilRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
