using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMPSP.API.ViewModel;
using ProjetoMPSP.Domain.Models;
using ProjetoMPSP.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMPSP.API.Controllers
{
    [Route("api/[controller]")]
    public class PesquisaController : Controller
    {
        private readonly MPSPDbContext _db;

        public PesquisaController(MPSPDbContext db)
        {
            _db = db;
        }

        //GET de Pesquisas ordenando da pesquisa mais recente
        [HttpGet]
        public ActionResult<List<PesquisaViewModel>> GetPesquisas()
        {
            return _db.Pesquisas.Include(x => x.Arisp)
                                .Include(x => x.Arpensp)
                                .Include(x => x.Cadesp)
                                .Include(x => x.Caged)
                                .Include(x => x.Censec)
                                .Include(x => x.Detran)
                                .Include(x => x.Infocrim)
                                //.Include(x => x.Arisp) -> JUCESP
                                .Include(x => x.Siel)
                                .Include(x => x.Sivec)
                                .OrderByDescending(x => x.IdPesquisa)
                                .Select(x => new PesquisaViewModel
                                {
                                    idpesquisa = x.IdPesquisa,
                                    datapesquisa = x.DataPesquisa,
                                    Arisp = new { Exist = x.Arisp.Count() != 0 ? true : false }.Exist,
                                    Arpensp = new { Exist = x.Arpensp != null ? true : false }.Exist,
                                    Cadesp = new { Exist = x.Cadesp != null ? true : false }.Exist,
                                    Caged = new { Exist = x.Caged != null ? true : false }.Exist,
                                    Censec = new { Exist = x.Censec != null ? true : false }.Exist,
                                    Detran = new { Exist = x.Detran != null ? true : false }.Exist,
                                    Infocrim = new { Exist = x.Infocrim != null ? true : false }.Exist,
                                    Siel = new { Exist = x.Siel != null ? true : false }.Exist,
                                    Sivec = new { Exist = x.Sivec != null ? true : false }.Exist,
                                }).ToList();
        }
    }
}
