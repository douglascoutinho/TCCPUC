using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;

namespace RiscSegPre.Infra.Data.Repositories
{
    public class ClienteRepository
            : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly DataContext context;

        public ClienteRepository(DataContext context)
               : base(context)
        {
            this.context = context;
        }
    }
}
