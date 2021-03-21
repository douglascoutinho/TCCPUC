namespace RiscSegPre.Domain.Entities.TemplateMethod
{
    public class MontarPesoNota : AddPesoNota
    {
        public override NotaAvaliacaoProcedimento AddPesoProcedimento()
        {
            return new NotaAvaliacaoProcedimento(0, 5, 8, 10, 7);
        }

        public override NotaMeioProtecaoFisico AddPesoFisico()
        {
            return new NotaMeioProtecaoFisico(0, 10, 3, 45, 67, 89, 35, 12);
        }

        public override NotaMeioProtecaoHumano AddPesoHumano()
        {
            return new NotaMeioProtecaoHumano(0, 10, 80, 56, 67);
        }

        public override NotaMeioProtecaoTecnico AddPesoTecnico()
        {
            return new NotaMeioProtecaoTecnico(0, 56, 75, 35, 78, 9, 6, 33);
        }
    }
}
