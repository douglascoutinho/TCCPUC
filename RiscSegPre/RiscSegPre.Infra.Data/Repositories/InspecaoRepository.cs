using Microsoft.EntityFrameworkCore;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;
using System.Linq;

namespace RiscSegPre.Infra.Data.Repositories
{
    public class InspecaoRepository
            : BaseRepository<Inspecao>, IInspecaoRepository
    {
        private readonly DataContext context;

        public InspecaoRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }

        public override void Insert(Inspecao obj)
        {
            context.Add(obj);
            context.SaveChanges();
        }

        public override void Update(Inspecao obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.NotaAvaliacaoProcedimento.Update(obj.id_notaAvaliacaoProcedimentoNavigation);
            context.NotaMeioProtecaoFisico.Update(obj.id_notaMeioProtecaoFisicoNavigation);
            context.NotaMeioProtecaoHumano.Update(obj.id_notaMeioProtecaoHumanoNavigation);
            context.NotaMeioProtecaoTecnico.Update(obj.id_notaMeioProtecaoTecnicoNavigation);

            context.SaveChanges();
        }

        public override Inspecao GetById(int id)
        {
            return context.Inspecao
                .AsNoTracking()
                .Include(x => x.id_notaAvaliacaoProcedimentoNavigation)
                .Include(x => x.id_notaMeioProtecaoFisicoNavigation)
                .Include(x => x.id_notaMeioProtecaoTecnicoNavigation)
                .Include(x => x.id_notaMeioProtecaoHumanoNavigation)
                .Where(x => x.id_inspecao == id)
                .FirstOrDefault();
        }

        public override IQueryable<Inspecao> GetAll()
        {
            return context.Inspecao
            .AsNoTracking()
            .Include(x => x.id_predioNavigation)
            .Include(x => x.id_apartamentoNavigation)
            .Include(x => x.id_localNavigation)
            .Include(x => x.id_clienteNavigation);
        }
    }
}
