using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jsreport.AspNetCore;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjetoMPSP.Domain.Models;
using ProjetoMPSP.Infrastructure.DbContexts;

namespace ProjetoMPSP.API.Pages
{
    [MiddlewareFilter(typeof(JsReportPipeline))]
    public class relatorioModel : PageModel
    {
        private readonly MPSPDbContext _db;
        public Pesquisa relatorio { get; set; }
        public relatorioModel(MPSPDbContext db)
        {
            _db = db;
        }

        public ActionResult OnGet(int id)
        {
            var pesquisa = _db.Pesquisas.Where(x => x.IdPesquisa == id).SingleOrDefault();
            if (pesquisa != null)
            {
                relatorio = pesquisa;
                relatorio.Cadesp = _db.Cadesp.Where(x => x.IdPesquisa == id).SingleOrDefault();

                HttpContext.JsReportFeature()
                       .Recipe(Recipe.ChromePdf)
                       .OnAfterRender((r) => HttpContext.Response.Headers["Content-Disposition"] = $"attachment; filename=\"Relatorio.pdf\"");

                return Page();
            }
            return NotFound();
        }
    }
}