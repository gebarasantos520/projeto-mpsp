using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMPSP.API.Services;
using ProjetoMPSP.API.ViewModel;
using ProjetoMPSP.Domain.Models;
using ProjetoMPSP.Infrastructure.DbContexts;
using System;
using System.Linq;

namespace ProjetoMPSP.API.Controllers
{
    [Route("api/[controller]")]
    public class ArpenspController : Controller
    {
        private readonly ScrapingService scrap;
        private readonly MPSPDbContext _db;

        public ArpenspController(MPSPDbContext db)
        {
            _db = db;
            scrap = new ScrapingService();
        }

        //POST de Dados de extração do Arpensp para inserir a Pesquisa
        [HttpPost("{id?}")]
        public ActionResult PostArpensp([FromBody] ExtracaoArpensp dados, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var extracao = scrap.ScrapingArpensp(dados.numeroProcesso);
                if (extracao == null) { return BadRequest(); }

                if (id != null)
                {
                    var _pesquisa = _db.Pesquisas.SingleOrDefault(x => x.IdPesquisa == int.Parse(id));
                    if (_pesquisa == null) { return BadRequest(); }

                    _pesquisa.Arpensp = new Arpensp
                    {
                        Acervo = extracao.Acervo,
                        CartorioRegistro = extracao.CartorioRegistro,
                        DataCasamento = DateTime.Parse(extracao.DataCasamento).Date,
                        DataEntrada = DateTime.Parse(extracao.DataEntrada).Date,
                        DataRegistro = DateTime.Parse(extracao.DataRegistro),
                        Matricula = extracao.Matricula,
                        NomeConjuge1 = extracao.NomeConjuge1,
                        NomeConjuge2 = extracao.NomeConjuge2,
                        NomeNovoConjuge1 = extracao.NomeNovoConjuge1,
                        NomeNovoConjuge2 = extracao.NomeNovoConjuge2,
                        numeroCNS = extracao.NumeroCNS,
                        NumeroFolha = extracao.NumeroFolha,
                        NumeroLivro = extracao.NumeroFolha,
                        NumeroProcesso = dados.numeroProcesso,
                        NumeroRegistro = extracao.NumeroRegistro,
                        TipoLivro = extracao.TipoLivro,
                        UF = extracao.UF
                    };

                    _db.Pesquisas.Update(_pesquisa);
                    _db.SaveChanges();

                    return Ok(_pesquisa.IdPesquisa);
                }

                var pesquisa = new Pesquisa
                {
                    DataPesquisa = DateTime.Now,
                    Arpensp = new Arpensp
                    {
                        Acervo = extracao.Acervo,
                        CartorioRegistro = extracao.CartorioRegistro,
                        DataCasamento = DateTime.Parse(extracao.DataCasamento).Date,
                        DataEntrada = DateTime.Parse(extracao.DataEntrada).Date,
                        DataRegistro = DateTime.Parse(extracao.DataRegistro).Date,
                        Matricula = extracao.Matricula,
                        NomeConjuge1 = extracao.NomeConjuge1,
                        NomeConjuge2 = extracao.NomeConjuge2,
                        NomeNovoConjuge1 = extracao.NomeNovoConjuge1,
                        NomeNovoConjuge2 = extracao.NomeNovoConjuge2,
                        numeroCNS = extracao.NumeroCNS,
                        NumeroFolha = extracao.NumeroFolha,
                        NumeroLivro = extracao.NumeroFolha,
                        NumeroProcesso = dados.numeroProcesso,
                        NumeroRegistro = extracao.NumeroRegistro,
                        TipoLivro = extracao.TipoLivro,
                        UF = extracao.UF
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