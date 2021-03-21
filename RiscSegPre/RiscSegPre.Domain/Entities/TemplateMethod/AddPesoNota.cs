namespace RiscSegPre.Domain.Entities.TemplateMethod
{
    public abstract class AddPesoNota
    {
        protected void Montar()
        {
            this.AddPesoProcedimento();
            this.AddPesoFisico();
            this.AddPesoHumano();
            this.AddPesoTecnico();
        }

        public abstract NotaAvaliacaoProcedimento AddPesoProcedimento();
        public abstract NotaMeioProtecaoFisico AddPesoFisico();
        public abstract NotaMeioProtecaoHumano AddPesoHumano();
        public abstract NotaMeioProtecaoTecnico AddPesoTecnico();
        public virtual void gancho() { }
    }
}
