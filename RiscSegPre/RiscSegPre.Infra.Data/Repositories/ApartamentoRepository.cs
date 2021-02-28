using Microsoft.EntityFrameworkCore;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;
using System.Linq;

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

        public override IQueryable<Apartamento> GetAll()
        {
            return context.Apartamento.Include(x => x.id_predioNavigation).AsNoTracking().AsQueryable();
        }
    }
}
