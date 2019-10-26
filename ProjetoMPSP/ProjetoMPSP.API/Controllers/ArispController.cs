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
    public class ArispController : Controller
    {
        private readonly ScrapingService scrap;
        private readonly MPSPDbContext _db;

        public ArispController(MPSPDbContext db, IConfiguration conf)
        {
            _db = db;
            scrap = new ScrapingService(conf);
        }

        //PUT de Auth para validar o Usuario antes de prosseguir com a Pesquisa
        [HttpPut]
        public ActionResult PutAuthArisp()
        {
            var autenticado = scrap.AuthArisp(x => x.Dispose());
            if (autenticado == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        //POST de Dados de extração do Arisp para inserir a Pesquisa
        [HttpPost("{id?}")]
        public ActionResult PostArisp([FromBody]ExtracaoArisp arisp, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var extracao = scrap.ScrapingArisp(arisp.documento);
                if (extracao.Count == 0 || extracao == null) { return BadRequest(); }
                if (id != null)
                {
                    var _pesquisa = _db.Pesquisas.SingleOrDefault(x => x.IdPesquisa == int.Parse(id));
                    if (_pesquisa == null) { return BadRequest(); }

                    var _dadosArisp = new List<Arisp>();
                    foreach (var dado in extracao)
                    {
                        _dadosArisp.Add(new Arisp
                        {
                            IdArisp = dado.IdArisp,
                            NomeOriginal = dado.NomeOriginal,
                            DataUpload = DateTime.Now,
                            Nome = dado.Nome,
                            Documento = dado.Documento
                        });
                    }

                    _pesquisa.Arisp = _dadosArisp;

                    _db.Pesquisas.Update(_pesquisa);
                    _db.SaveChanges();

                    return Ok(_pesquisa.IdPesquisa);
                }

                var dadosArisp = new List<Arisp>();
                foreach (var dado in extracao)
                {
                    dadosArisp.Add(new Arisp
                    {
                        IdArisp = dado.IdArisp,
                        NomeOriginal = dado.NomeOriginal,
                        DataUpload = DateTime.Now,
                        Nome = dado.Nome,
                        Documento = dado.Documento
                    });
                }

                var pesquisa = new Pesquisa
                {
                    DataPesquisa = DateTime.Now,
                    Arisp = dadosArisp
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
