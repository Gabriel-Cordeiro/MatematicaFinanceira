using System;
using System.Collections.Generic;
using System.Linq;

namespace  MatematicaFinanceira
{
    public class SistemaDeAmortizacaoConstante
    {
        public static List<Parcela> CalcularParcelas(decimal saldoDevedor, decimal taxaDeJuros, int prazo)
        {
            var parcelas = new List<Parcela>();
            var saldoDevedorAtual = saldoDevedor;
            var amortizacaoAtravesDoPrazo = ValorAmortizacao(saldoDevedor,prazo);

            parcelas.Add(new Parcela(juros: 0, amortizacao: 0, saldoDevedor: saldoDevedor));

            for (var numeroDaParcela = 0; numeroDaParcela < prazo; numeroDaParcela++)
            {
                var juros = JurosCompostos.CalcularJuros(saldoDevedorAtual, taxaDeJuros, prazo: 1);
                saldoDevedorAtual -= amortizacaoAtravesDoPrazo;
                parcelas.Add(new Parcela(juros, amortizacaoAtravesDoPrazo, saldoDevedorAtual));
            }
            return parcelas;
        }

        public static decimal ValorAmortizacao(decimal saldoDevedor, int prazo)
        {
            return (saldoDevedor/prazo);
        }

        public static decimal SaldoDevedorEmOrdemT(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT)
        {
            return CalcularParcelas(saldoDevedor, taxaDeJuros, prazo)[ordemT].SaldoDevedor;
        }

        public static decimal SaldoDevedorEmOrdemTMenosUm(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT)
        {
            return CalcularParcelas(saldoDevedor, taxaDeJuros, prazo)[ordemT - 1].SaldoDevedor;
        }

        public static decimal SaldoJurosOrdemT(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT)
        {
            return CalcularParcelas(saldoDevedor, taxaDeJuros, prazo)[ordemT].Juros;
        }

        public static decimal ValorPrestacaoOrdemT(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT)
        {
            return CalcularParcelas(saldoDevedor, taxaDeJuros, prazo)[ordemT].Prestacao;
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
            var sac = CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
            var valorAcumulado = 0M;
            for (int i = 0; i <= ordemT; i++)
            {
                valorAcumulado += sac[i].Juros;
            }

            return valorAcumulado;
        }

        public static decimal JurosAcumuladoEntreTeK(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT, int k)
        {
            var sac = CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);
            var valorAcumulado = 0M;
            for (int i = ordemT + 1; i <= k; i++)
            {
                valorAcumulado += sac[i].Juros;
            }
            return valorAcumulado.Arredondado(2);
        }

        public static decimal ValorParcelaAcumuladaAteOrdemT(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT)
        {
            var sac = CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);

            var valorAcumuladoParcela = 0M;

            for (int i = 0; i <= ordemT; i++)
            {
                valorAcumuladoParcela += sac[i].Prestacao;
            }

            return valorAcumuladoParcela;
        }

        public static decimal ValorParcelaAcumuladaOrdemTeK(decimal saldoDevedor, decimal taxaDeJuros, int prazo, int ordemT, int k)
        {
            var sac = CalcularParcelas(saldoDevedor, taxaDeJuros, prazo);

            var valorAcumuladoParcela = 0M;

            for (int i = ordemT + 1; i <= k; i++)
            {
                valorAcumuladoParcela += sac[i].Prestacao;
            }

            return valorAcumuladoParcela;
        }

        public static decimal DecrescimoPrestacoes(decimal saldoDevedor, decimal taxaDeJuros, int prazo)
        {
            return (ValorAmortizacao(saldoDevedor, prazo) * taxaDeJuros).Arredondado(2);

        }

    }
}