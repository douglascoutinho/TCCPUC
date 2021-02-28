using Microsoft.EntityFrameworkCore;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;
using System.Linq;

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

        public override IQueryable<Bairro> GetAll()
        {
            return context.Bairro
                .Include(x => x.id_delegaciaNavigation)
                .Include(x => x.id_batalhaoNavigation)
                .Include(x => x.id_riscoNavigation);
        }
    }
}
