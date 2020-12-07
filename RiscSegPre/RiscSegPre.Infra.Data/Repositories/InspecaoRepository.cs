using Microsoft.EntityFrameworkCore;
using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;

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
    }
}
