using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;

namespace RiscSegPre.Infra.Data.Repositories
{
    public class BairroRepository
        : BaseRepository<Bairro>, IBairroRepository
    {
        private readonly DataContext context;

        public BairroRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}
