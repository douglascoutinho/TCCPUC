using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;

namespace RiscSegPre.Infra.Data.Repositories
{
    public class PredioRepository
            : BaseRepository<Predio>, IPredioRepository
    {
        private readonly DataContext context;

        // Injeção de Dependência
        public PredioRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
