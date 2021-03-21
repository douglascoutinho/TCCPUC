namespace RiscSegPre.Domain.Entities
{
    public static class CalcularNota
    {
        public static Inspecao CalcularRisco(Inspecao inspecao)
        {
            var meidiaAvaliacao = inspecao.id_notaAvaliacaoProcedimentoNavigation.MontarNota(inspecao);
            var meidiaProtecaoFisico = inspecao.id_notaMeioProtecaoFisicoNavigation.MontarNota(inspecao);
            var meidiaProtecaoHumano = inspecao.id_notaMeioProtecaoHumanoNavigation.MontarNota(inspecao);
            var meidiaProtecaoTecnico = inspecao.id_notaMeioProtecaoTecnicoNavigation.MontarNota(inspecao);

            var media_geral = ((meidiaAvaliacao + meidiaProtecaoFisico + meidiaProtecaoHumano + meidiaProtecaoTecnico)) / 4;

            inspecao = inspecao.InserirMediaGeral(inspecao, media_geral);

            var motivos = string.Empty;

            if (meidiaAvaliacao < 60)
                motivos = "Avalição de Procedimentos";

            if (meidiaProtecaoFisico < 60)
                motivos += motivos.Length > 0 ? ", Meio Proteção Fisico, " : "Meio Proteção Fisico";

            if (meidiaProtecaoHumano < 60)
                motivos += motivos.Length > 0 ? " Meio Proteção Humano, " : "Meio Proteção Humano";

            if (meidiaProtecaoTecnico < 60)
                motivos += motivos.Length > 0 ? " Meio Proteção Tecnico, " : "Meio Proteção Técnico";


            return inspecao.InserirSituacao(inspecao, motivos);
        }
    }
}