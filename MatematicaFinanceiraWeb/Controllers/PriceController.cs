﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  MatematicaFinanceira;
using MatematicaFinanceiraWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MatematicaFinanceiraWeb.Controllers
{
    public class PriceController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        // GET: /<controller>/
        [HttpPost]
        public IActionResult GerarTabela(ValoresFinanciamento valores, string tipoSubmit)
        {
            if (tipoSubmit.Equals("geraTabela")){
                valores.Parcelas = SistemaDeAmortizacaoPrice.CalcularParcelas(valores.Valor,valores.TaxaJuros,valores.Prazo);
                return View("Tabela", valores);
            }
            return View();
        }
    }
}
