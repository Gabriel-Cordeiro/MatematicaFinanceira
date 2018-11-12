using  MatematicaFinanceira;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalculos
{
    [TestClass]
    public class UnitTestSac
    {
        public decimal valorFinanciamento = 100000.00M;
        public int numeroDeParcelas = 10;
        public decimal taxaDeJuros = 0.045M;

        [TestMethod]
        public void DeveGerarTabelaSac()
        {
            var sac = SistemaDeAmortizacaoConstante.CalcularParcelas(valorFinanciamento, taxaDeJuros, numeroDeParcelas);
            Assert.AreNotEqual(null, sac);
        }

        [TestMethod]
        public void DeveGerarValorAmortizacao()
        {
            var esperado = 10000M;
            var amortizacao = SistemaDeAmortizacaoConstante.ValorAmortizacao(valorFinanciamento, numeroDeParcelas);
            Assert.IsTrue(esperado == amortizacao);
        }

        [TestMethod]
        public void DeveGerarSaldoDevedorEmOrdemT()
        {
            int ordemT = 7;
            var esperado = 30000M;
            var saldoDevedor = SistemaDeAmortizacaoConstante.SaldoDevedorEmOrdemT(valorFinanciamento, taxaDeJuros,numeroDeParcelas,ordemT);
            Assert.IsTrue(esperado == saldoDevedor);
        }

        [TestMethod]
        public void DeveGerarSaldoDevedorEmOrdemTMenosUm()
        {
            int ordemT = 7;
            var esperado = 40000M;
            var saldoDevedor = SistemaDeAmortizacaoConstante.SaldoDevedorEmOrdemTMenosUm(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordemT);
            Assert.IsTrue(esperado == saldoDevedor);
        }

        [TestMethod]
        public void DeveGerarParcelaJurosEmOrdemT()
        {
            int ordemT = 7;
            var esperado = 1800M;
            var saldoDevedor = SistemaDeAmortizacaoConstante.SaldoJurosOrdemT(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordemT);
            Assert.IsTrue(esperado == saldoDevedor);
        }

        [TestMethod]
        public void DeveGerarValorPrestacaoEmOrdemT()
        {
            int ordemT = 7;
            var esperado = 11800M;
            var saldoDevedor = SistemaDeAmortizacaoConstante.ValorPrestacaoOrdemT(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordemT);
            Assert.IsTrue(esperado == saldoDevedor);
        }

        [TestMethod]
        public void DeveGerarAmortizacaoEmOrdemTeK()
        {
            int ordemT = 1;
            int k = 7;
            var esperado = 60000M;
            var saldoDevedor = SistemaDeAmortizacaoConstante.AmortizacaoAcumuladaEntreTeK(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordemT,k);
            Assert.IsTrue(esperado == saldoDevedor);
        }

        [TestMethod]
        public void DeveGerarSomaJurosEmOrdemT()
        {
            int ordemT = 7;
            var esperado = 22050M;
            var saldoDevedor = SistemaDeAmortizacaoConstante.ValorJurosAcumuladoEmOrdemT(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordemT);
            Assert.IsTrue(esperado == saldoDevedor);
        }

        [TestMethod]
        public void DeveGerarSomaJurosEmOrdemTeK()
        {
            int ordemT = 2;
            int k = 5;
            var esperado = 9450M;
            var saldoDevedor = SistemaDeAmortizacaoConstante.JurosAcumuladoEntreTeK(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordemT,k);
            Assert.IsTrue(esperado == saldoDevedor);
        }

        [TestMethod]
        public void DeveGerarSomaParcelaEmOrdemT()
        {
            int ordemT = 3;
            var esperado = 42150M;
            var prestacaoAcumulada = SistemaDeAmortizacaoConstante.ValorParcelaAcumuladaAteOrdemT(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordemT);
            Assert.IsTrue(esperado == prestacaoAcumulada);
        }

        [TestMethod]
        public void DeveGerarSomaParcelaEmOrdemTeK()
        {
            int ordemT = 3;
            int k = 5;
            var esperado = 25850M;
            var prestacaoAcumulada = SistemaDeAmortizacaoConstante.ValorParcelaAcumuladaOrdemTeK(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordemT,k);
            Assert.IsTrue(esperado == prestacaoAcumulada);
        }

        [TestMethod]
        public void DeveGerarValorDecrescimoParcela()
        {
            var esperado = 450M;
            var decrescimo = SistemaDeAmortizacaoConstante.DecrescimoPrestacoes(valorFinanciamento, taxaDeJuros, numeroDeParcelas);
            Assert.IsTrue(esperado == decrescimo);
        }
    }
}
