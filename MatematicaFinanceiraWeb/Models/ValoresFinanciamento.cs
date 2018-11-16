using MatematicaFinanceira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatematicaFinanceiraWeb.Models
{
    public class ValoresFinanciamento
    {
        public decimal Valor { get; set; }

        private decimal _taxaJuros;
        public decimal TaxaJuros
        {
            get { return _taxaJuros; }
            set
            {
                _taxaJuros = value / 100;
            }
        }
        public List<Parcela> Parcelas { get; set; }
        public int Prazo { get; set; }

        public decimal RetornaValorCalculo(string opcaoCalcular, int t, int k)
        {
            var resultado = 0M;
            if (opcaoCalcular == "1") resultado = SistemaDeAmortizacaoPrice.CalcularValorPrestacao(Valor, TaxaJuros, Prazo);
            if (opcaoCalcular == "2") resultado = SistemaDeAmortizacaoPrice.SaldoDevedorEmOrdemT(Valor, TaxaJuros, Prazo,t);
            if (opcaoCalcular == "3") resultado = SistemaDeAmortizacaoPrice.SaldoDevedorEmOrdemT(Valor, TaxaJuros, Prazo, t-1);
            if (opcaoCalcular == "4") resultado = SistemaDeAmortizacaoPrice.ValorParcelaJurosEmOrdemT(Valor, TaxaJuros, Prazo,t);
            if (opcaoCalcular == "5") resultado = SistemaDeAmortizacaoPrice.ValorJurosAcumuladoEmOrdemT(Valor, TaxaJuros, Prazo,t);
            if (opcaoCalcular == "6") resultado = SistemaDeAmortizacaoPrice.JurosAcumuladoEntreTeK(Valor, TaxaJuros, Prazo,t,k);
            if (opcaoCalcular == "7") resultado = SistemaDeAmortizacaoPrice.ValorPrimeiraAmortizacao(Valor, TaxaJuros, Prazo);
            if (opcaoCalcular == "8") resultado = SistemaDeAmortizacaoPrice.ValorAmotizacaoEmOrdemT(Valor, TaxaJuros, Prazo,t);
            if (opcaoCalcular == "9") resultado = SistemaDeAmortizacaoPrice.ValorAmortizacaoAcumuladaAteOrdemT(Valor, TaxaJuros, Prazo,t);
            if (opcaoCalcular == "10") resultado = SistemaDeAmortizacaoPrice.AmortizacaoAcumuladaEntreTeK(Valor, TaxaJuros, Prazo,t,k);

            return resultado;
        }
    }
}
