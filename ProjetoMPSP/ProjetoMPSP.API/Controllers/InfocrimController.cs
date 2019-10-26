using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProjetoMPSP.API.Services;
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
    public class InfocrimController : Controller
    {
        private readonly ScrapingService scrap;
        private readonly MPSPDbContext _db;

        public InfocrimController(MPSPDbContext db, IConfiguration conf)
        {
            _db = db;
            scrap = new ScrapingService(conf);
        }

        [HttpPut]
        public ActionResult PutAuthInfocrim([FromBody]ExtracaoInfocrim login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var autenticado = scrap.AuthInfocrim(login.usuario, login.senha, x => x.Dispose());
            if (autenticado == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("{id?}")]
        public ActionResult PostInfocrim([FromBody]ExtracaoInfocrim dados, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var extracao = scrap.ScrapingInfrocrim(dados.usuario, dados.senha);
                if (extracao == null) { return BadRequest(); }

                if (id != null)
                {
                    var _pesquisa = _db.Pesquisas.SingleOrDefault(x => x.IdPesquisa == int.Parse(id));
                    if (_pesquisa == null) { return BadRequest(); }

                    _pesquisa.Infocrim = new Infocrim
                    {
                        DataUpload = DateTime.Now,
                        NomeOriginal = extracao.NomeOriginal
                    };

                    _db.Pesquisas.Update(_pesquisa);
                    _db.SaveChanges();

                    return Ok(_pesquisa.IdPesquisa);
                }

                var pesquisa = new Pesquisa
                {
                    DataPesquisa = DateTime.Now,
                    Infocrim = new Infocrim
                    {
                        DataUpload = DateTime.Now,
                        NomeOriginal = extracao.NomeOriginal
                    }
                };

                _db.Pesquisas.Add(pesquisa);
                _db.SaveChanges();

                return Ok(pesquisa.IdPesquisa);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}
