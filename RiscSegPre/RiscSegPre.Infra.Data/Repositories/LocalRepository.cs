using Microsoft.EntityFrameworkCore;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;
using System.Linq;

namespace RiscSegPre.Infra.Data.Repositories
{
    public class LocalRepository
        : BaseRepository<Local>, ILocalRepository
    {
        private readonly DataContext context;

        public LocalRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }

        public override IQueryable<Local> GetAll()
        {
            return context.Local
                .Include(x => x.id_delegaciaNavigation)
                .Include(x => x.id_batalhaoNavigation)
                .Include(x => x.id_riscoNavigation);
        }
    }
}
