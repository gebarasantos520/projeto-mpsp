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
    public class SielController : Controller
    {
        private readonly ScrapingService scrap;
        private readonly MPSPDbContext _db;

        public SielController(MPSPDbContext db)
        {
            _db = db;
            scrap = new ScrapingService();
        }

        //PUT de Auth para validar o Usuario antes de prosseguir com a Pesquisa
        [HttpPut]
        public ActionResult PutSielAuth([FromBody]LoginSiel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var autenticado = scrap.AuthSiel(login.email, login.senha);
            if (autenticado == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        //POST de Dados de extração do Siel para inserir a Pesquisa
        [HttpPost("{id?}")]
        public ActionResult PostSiel([FromBody]ExtracaoSiel dados,string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var extracao = scrap.ScrapingSiel(dados.email, dados.senha, dados.numeroProcesso, dados.nome);
                if (extracao == null) { return BadRequest(); }

                if (id != null)
                {
                    var _pesquisa = _db.Pesquisas.SingleOrDefault(x => x.IdPesquisa == int.Parse(id));
                    if (_pesquisa == null) { return BadRequest(); }

                    _pesquisa.Siel = new Siel
                    {
                        Nome = extracao.Nome,
                        CodigoValidacao = extracao.CodigoValidacao,
                        DataDomicilio = DateTime.Parse(extracao.DataDomicilio).Date,
                        Municipio = extracao.Municipio,
                        Naturalidade = extracao.Naturalidade,
                        NomeMae = extracao.NomeMae,
                        NomePai = extracao.NomePai,
                        Titulo = extracao.Titulo,
                        Uf = extracao.UF,
                        Zona = extracao.Zona,
                        Endereco = extracao.Endereco,
                        DataNascimento = extracao.DataNascimento
                    };

                    _db.Pesquisas.Update(_pesquisa);
                    _db.SaveChanges();

                    return Ok(_pesquisa.IdPesquisa);
                }

                var pesquisa = new Pesquisa
                {
                    DataPesquisa = DateTime.Now,
                    Siel = new Siel
                    {
                        Nome = extracao.Nome,
                        CodigoValidacao = extracao.CodigoValidacao,
                        DataDomicilio = DateTime.Parse(extracao.DataDomicilio).Date,
                        Municipio = extracao.Municipio,
                        Naturalidade = extracao.Naturalidade,
                        NomeMae = extracao.NomeMae,
                        NomePai = extracao.NomePai,
                        Titulo = extracao.Titulo,
                        Uf = extracao.UF,
                        Zona = extracao.Zona,
                        Endereco = extracao.Endereco,
                        DataNascimento = extracao.DataNascimento
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