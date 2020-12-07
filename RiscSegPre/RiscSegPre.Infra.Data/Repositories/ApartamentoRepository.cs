using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;

namespace RiscSegPre.Infra.Data.Repositories
{
    public class ApartamentoRepository
                : BaseRepository<Apartamento>, IApartamentoRepository
    {
        private readonly DataContext context;

        public ApartamentoRepository(DataContext context)
            :base(context) 
        {
            this.context = context;
        }
    }
}
