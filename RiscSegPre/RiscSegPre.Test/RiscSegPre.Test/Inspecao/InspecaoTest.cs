using NUnit.Framework;
using RiscSegPre.Domain.Entities;

namespace RiscSegPre.Test.Inspecao
{
    [TestFixture]
    public class InspecaoTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void TestInspecao()
        {
            const int resultado_esperado = 55;

            var inspecao = CalcularNota.CalcularRisco(CarregarInspecao());
            Assert.AreEqual(resultado_esperado, inspecao.nota);
        }

        private Domain.Entities.Inspecao CarregarInspecao()
        {
            return new Domain.Entities.Inspecao
                (
                    new NotaMeioProtecaoFisico(10, 10, 10, 10, 10, 10, 10, 10),
                    new NotaMeioProtecaoHumano(80, 80, 80, 80, 80),
                    new NotaMeioProtecaoTecnico(70, 70, 70, 70, 70, 70, 70, 70),
                    new NotaAvaliacaoProcedimento(60, 60, 60, 60, 60)
                );
        }
    }
}