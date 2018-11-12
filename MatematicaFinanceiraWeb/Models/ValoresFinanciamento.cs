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
    }
}
