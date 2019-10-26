using Microsoft.AspNetCore.Mvc;
using ProjetoMPSP.API.Services;
using ProjetoMPSP.API.ViewModel;
using ProjetoMPSP.Domain.Models;
using ProjetoMPSP.Infrastructure.DbContexts;
using System;
using System.Linq;

namespace ProjetoMPSP.API.Controllers
{
    [Route("api/[controller]")]
    public class CensecController : Controller
    {
        private readonly ScrapingService scrap;
        private readonly MPSPDbContext _db;

        public CensecController(MPSPDbContext db)
        {
            _db = db;
            scrap = new ScrapingService();
        }

        //PUT de Auth para validar o Usuario antes de prosseguir com a Pesquisa
        [HttpPut]
        public ActionResult PutCensecAuth([FromBody]LoginCensec login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var autenticado = scrap.AuthCensec(login.login, login.senha);
            if (autenticado == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        //POST de Dados de extração do Censec para inserir a Pesquisa
        [HttpPost("{id?}")]
        public ActionResult PostCensec([FromBody]ExtracaoCensec dados, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var extracao = scrap.ScrapingCensec(dados.login, dados.senha, dados.documento);
                if (extracao == null) { return BadRequest(); }

                if (id != null)
                {
                    var _pesquisa = _db.Pesquisas.SingleOrDefault(x => x.IdPesquisa == int.Parse(id));
                    if (_pesquisa == null) { return BadRequest(); }

                    _pesquisa.Censec = new Censec
                    {
                        Ato = extracao.Ato,
                        Carga = extracao.Carga,
                        DataAto = (extracao.DiaAto + "/" + extracao.MesAto + "/" + extracao.AnoAto).Trim(),
                        Documento = dados.documento,
                        Folha = extracao.Folha,
                        Livro = extracao.Livro,
                        DataCarga = (extracao.MesCarga + "/" + extracao.AnoCarga).Trim(),
                    };

                    _db.Pesquisas.Update(_pesquisa);
                    _db.SaveChanges();

                    return Ok(_pesquisa.IdPesquisa);
                }

                var pesquisa = new Pesquisa
                {
                    DataPesquisa = DateTime.Now,
                    Censec = new Censec
                    {
                        Ato = extracao.Ato,
                        Carga = extracao.Carga,
                        DataAto = (extracao.DiaAto + "/" + extracao.MesAto + "/" + extracao.AnoAto).Trim(),
                        Documento = dados.documento,
                        Folha = extracao.Folha,
                        Livro = extracao.Livro,
                        DataCarga = (extracao.MesCarga + "/" + extracao.AnoCarga).Trim(),
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