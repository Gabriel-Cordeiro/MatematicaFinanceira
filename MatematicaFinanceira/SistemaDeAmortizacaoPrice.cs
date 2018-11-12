using System;
using System.Collections.Generic;
using System.Linq;

namespace  MatematicaFinanceira
{
    public class SistemaDeAmortizacaoPrice
    {
        public static List<Parcela> CalcularParcelas(decimal saldoDevedor, decimal taxaDeJuros, int prazo)
        {
            var parcelas = new List<Parcela>
            {
                new Parcela(juros: 0, amortizacao: 0, saldoDevedor: saldoDevedor)
            };

            var saldoDevedorAtual = saldoDevedor;
            var coeficienteK = (taxaDeJuros * (1 + taxaDeJuros).ElevadoPor(prazo)) / ((1 + taxaDeJuros).ElevadoPor(prazo) - 1);
            var prestacaoAtravesDoPrazo = (coeficienteK * saldoDevedor).Arredondado(2);

            for (var numeroDaParcela = 0; numeroDaParcela < prazo; numeroDaParcela++)
            {
                var juros = JurosCompostos.CalcularJuros(saldoDevedorAtual, taxaDeJuros, 1);
                var amortizacao = prestacaoAtravesDoPrazo - juros;
                saldoDevedorAtual -= amortizacao;
                var parcelaAtual = new Parcela(juros.Arredondado(2), amortizacao.Arredondado(2), saldoDevedorAtual.Arredondado(2));
                parcelas.Add(parcelaAtual);
            }

            return parcelas;
        }
        public static decimal CalcularValorPrestacao(decimal saldoDevedor, decimal taxaDeJuros, int prazo)
        {
            var coeficienteK = (taxaDeJuros * (1 + taxaDeJuros).ElevadoPor(prazo)) / ((1 + taxaDeJuros).ElevadoPor(prazo) - 1);
            return (coeficienteK * saldoDevedor).Arredondado(0);
        }

        public static decimal SaldoDevedorEmOrdemT(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT)
        {
            return CalcularParcelas(saldoDevedor, taxaDeJuros, prazo)[ordemT].SaldoDevedor;
        }

        public static decimal ValorParcelaJurosEmOrdemT(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT)
        {
            return CalcularParcelas(saldoDevedor, taxaDeJuros, prazo)[ordemT].Juros;
        }

        public static decimal ValorPrimeiraAmortizacao(decimal saldoDevedor, decimal taxaDeJuros, int prazo)
        {
            return CalcularParcelas(saldoDevedor, taxaDeJuros, prazo)[1].Amortizacao;
        }

        public static decimal ValorAmotizacaoEmOrdemT(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT)
        {
            return CalcularParcelas(saldoDevedor, taxaDeJuros, prazo)[ordemT].Amortizacao;
        }

        public static decimal ValorAmortizacaoAcumuladaAteOrdemT(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT)
        {
            var price = CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);

            var valorAcumuladoAmortizacao = 0M;

            for (int i = 0; i <= ordemT; i++)
            {
                valorAcumuladoAmortizacao += price[i].Amortizacao;
            }

            return valorAcumuladoAmortizacao;
        }

        public static decimal AmortizacaoAcumuladaEntreTeK(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT, int k)
        {
            var price = CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
            var valorAcumulado = 0M;
            for (int i = ordemT + 1; i <= k; i++)
            {
                valorAcumulado += price[i].Amortizacao;
            }
            return valorAcumulado.Arredondado(2);
        }

        public static decimal ValorJurosAcumuladoEmOrdemT(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT)
        {
            var price = CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
            var valorAcumulado = 0M;
            for (int i = 0; i <= ordemT; i++)
            {
                valorAcumulado += price[i].Juros;
            }

            return valorAcumulado;
        }


        public static decimal JurosAcumuladoEntreTeK(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT, int k)
        {
            var price = CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
            var valorAcumulado = 0M;
            for (int i = ordemT + 1; i <= k; i++)
            {
                valorAcumulado += price[i].Juros;
            }
            return valorAcumulado.Arredondado(2);
        }

    }
}