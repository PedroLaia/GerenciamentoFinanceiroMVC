using System.Diagnostics;
using GerenciamentoFinanceiroMVC.Data;
using GerenciamentoFinanceiroMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoFinanceiroMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }



        public IActionResult Index(string id)
        {

            var filtros = new Filtros(id);

            ViewBag.Filtros = filtros;
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Transacoes = _context.Transacoes.ToList();
            ViewBag.DataOperacao = Filtros.ValoresDataOperacao;

            IQueryable<Financeiro> consulta = _context.Financas
                .Include(x => x.Transacao).Include(x => x.Categoria);


            if (filtros.TemCategoria)
            {
                consulta = consulta.Where(c => c.CategoriaId == filtros.CategoriaId);
            }

            if (filtros.TemTransacao)
            {
                consulta = consulta.Where(c => c.TransacaoId == filtros.TransacaoId);
            }

            if (filtros.TemDataOperacao)
            {
                DateTime hoje = DateTime.Today;

                if (filtros.EPassado)
                {
                    consulta = consulta.Where(c => c.DataOperacao < hoje);
                }
                else if (filtros.EFuturo)
                {
                    consulta = consulta.Where(c => c.DataOperacao > hoje);
                }
                else
                {
                    consulta = consulta.Where(c => c.DataOperacao == hoje);
                }

            }

            var financas = consulta.OrderBy(d => d.DataOperacao).ToList();


                return View();
            

        }
    }
}

