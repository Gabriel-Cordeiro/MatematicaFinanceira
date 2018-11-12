using  MatematicaFinanceira;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCalculos
{
    [TestClass]
    public class UnitTestPrice
    {
        public decimal valorFinanciamento = 8530.20M;
        public int numeroDeParcelas = 10;
        public decimal taxaDeJuros = 0.03M;
        [TestMethod]
        public void DeveGerarTabelaPrice()
        {
            var price = SistemaDeAmortizacaoPrice.CalcularParcelas(valorFinanciamento, taxaDeJuros, numeroDeParcelas);
            Assert.AreNotEqual(null, price);
        }

        [TestMethod]
        public void CalcularParcelaPrice()
        {
            var EsperadoPrestacao = 1000;

            var valorPrestacao = SistemaDeAmortizacaoPrice.CalcularValorPrestacao(valorFinanciamento, taxaDeJuros, numeroDeParcelas);
            Assert.IsTrue(EsperadoPrestacao == valorPrestacao);
        }

        [TestMethod]
        public void CalcularSaldoDevedorEmOrdemT()
        {
            int t = 6;
            decimal saldoDevedorEsperado = 3717.10M;

            var saldoDevedor = SistemaDeAmortizacaoPrice.SaldoDevedorEmOrdemT(valorFinanciamento, taxaDeJuros, numeroDeParcelas, t);
            Assert.IsTrue(saldoDevedorEsperado == saldoDevedor);
        }

        [TestMethod]
        public void CalcularSaldoDevedorEmOrdemTMenosUm()
        {
            int t = 6;
            decimal saldoDevedorEsperado = 4579.71M;

            var saldoDevedor = SistemaDeAmortizacaoPrice.SaldoDevedorEmOrdemT(valorFinanciamento, taxaDeJuros, numeroDeParcelas, t - 1);
            Assert.IsTrue(saldoDevedorEsperado == saldoDevedor);
        }

        [TestMethod]
        public void CalcularValorJurosEmOrdemT()
        {
            int t = 6;
            decimal valorJurosEsperado = 137.39M;

            var valorJuros = SistemaDeAmortizacaoPrice.ValorParcelaJurosEmOrdemT(valorFinanciamento, taxaDeJuros, numeroDeParcelas, t);
            Assert.IsTrue(valorJurosEsperado == valorJuros);
        }

        [TestMethod]
        public void ValorPrimeiraAmortizacao()
        {
            decimal amortizacaoEsperada = 744.09M;

            var primeiraAmortizacao = SistemaDeAmortizacaoPrice.ValorPrimeiraAmortizacao(valorFinanciamento, taxaDeJuros, numeroDeParcelas);
            Assert.IsTrue(amortizacaoEsperada == primeiraAmortizacao);
        }

        [TestMethod]
        public void ValorAmortizacaoEmOrdemT()
        {
            int ordem = 10;
            decimal amortizacaoEsperada = 970.87M;

            var amortizacao = SistemaDeAmortizacaoPrice.ValorAmotizacaoEmOrdemT(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordem);
            Assert.IsTrue(amortizacaoEsperada == amortizacao);
        }

        [TestMethod]
        public void ValorAmortizacaoAcumuladaEmT()
        {
            int ordem = 10;
            decimal amortizacaoEsperada = 8530.20M;

            var amortizacao = SistemaDeAmortizacaoPrice.ValorAmortizacaoAcumuladaAteOrdemT(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordem);
            Assert.IsTrue(amortizacaoEsperada == amortizacao);
        }


        [TestMethod]
        public void ValorAmortizacaoAcumuladaEntreTeK()
        {
            int ordem = 2;
            int k = 5;
            decimal amortizacaoEsperada = 2439.98M;

            var amortizacao = SistemaDeAmortizacaoPrice.AmortizacaoAcumuladaEntreTeK(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordem,k);
            Assert.IsTrue(amortizacaoEsperada == amortizacao);
        }

        [TestMethod]
        public void JurosAcumuladosAteT()
        {
            int ordem = 5;
            decimal jurosEsperado = 1049.51M;

            var jurosAcumulado = SistemaDeAmortizacaoPrice.ValorJurosAcumuladoEmOrdemT(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordem);
            Assert.IsTrue(jurosAcumulado == jurosEsperado);
        }

        [TestMethod]
        public void ValorJurosAcumuladaEntreTeK()
        {
            int ordem = 2;
            int k = 5;
            decimal jurosEsperado = 560.02M;

            var juros = SistemaDeAmortizacaoPrice.JurosAcumuladoEntreTeK(valorFinanciamento, taxaDeJuros, numeroDeParcelas, ordem, k);
            Assert.IsTrue(jurosEsperado == juros);
        }

    }
}
