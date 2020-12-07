namespace RiscSegPre.Domain.Entities
{
    public static class CalcularNota
    {
        public static Inspecao CalcularRisco(Inspecao inspecao)
        {
            var meidiaAvaliacao = inspecao.id_notaAvaliacaoProcedimentoNavigation.CalcularMedia(inspecao);
            var meidiaProtecaoFisico = inspecao.id_notaMeioProtecaoFisicoNavigation.CalcularMedia(inspecao);
            var meidiaProtecaoHumano = inspecao.id_notaMeioProtecaoHumanoNavigation.CalcularMedia(inspecao);
            var meidiaProtecaoTecnico = inspecao.id_notaMeioProtecaoTecnicoNavigation.CalcularMedia(inspecao);

            inspecao.nota = ((meidiaAvaliacao + meidiaProtecaoFisico + meidiaProtecaoHumano + meidiaProtecaoTecnico)) / 4;

            inspecao.motivoReprovacao = string.Empty;

            if (meidiaAvaliacao < 60)
                inspecao.motivoReprovacao = "Avalição de Procedimentos";

            if (meidiaProtecaoFisico < 60)
                inspecao.motivoReprovacao += inspecao.motivoReprovacao.Length > 0 ? ", Meio Proteção Fisico, " : "Meio Proteção Fisico";

            if (meidiaProtecaoHumano < 60)
                inspecao.motivoReprovacao += inspecao.motivoReprovacao.Length > 0 ? " Meio Proteção Humano, " : "Meio Proteção Humano";

            if (meidiaProtecaoTecnico < 60)
                inspecao.motivoReprovacao += inspecao.motivoReprovacao.Length > 0 ? " Meio Proteção Tecnico, " : "Meio Proteção Técnico";

            if (inspecao.motivoReprovacao.Length > 0)
                inspecao.situacao = "Reprovada";
            else
                inspecao.situacao = "Aprovada";

            return inspecao;
        }
    }
}

