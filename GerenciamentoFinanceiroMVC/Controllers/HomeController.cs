using System.Diagnostics;
using GerenciamentoFinanceiroMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoFinanceiroMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


    }
}
