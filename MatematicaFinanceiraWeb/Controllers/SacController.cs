using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatematicaFinanceira;
using MatematicaFinanceiraWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatematicaFinanceiraWeb.Controllers
{
    public class SacController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GerarTabela(ValoresFinanciamento valores, string tipoSubmit, string opcoesCalcularSac, int t, int k)
        {
            if (tipoSubmit.Equals("geraTabela"))
            {
                valores.Parcelas = SistemaDeAmortizacaoConstante.CalcularParcelas(valores.Valor, valores.TaxaJuros, valores.Prazo);
                return View("Index", valores);
            }
            if (tipoSubmit.Equals("calcularOpcao"))
            {
                ViewData["Calculo"] = valores.RetornaValorCalculoSac(opcoesCalcularSac, t, k);
                return View("Index");
            }
            return View();
        }
    }
}
