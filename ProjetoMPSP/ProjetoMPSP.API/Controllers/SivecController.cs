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
    public class SivecController : Controller
    {
        private readonly ScrapingService scrap;
        private readonly MPSPDbContext _db;

        public SivecController(MPSPDbContext db)
        {
            _db = db;
            scrap = new ScrapingService();
        }

        //PUT de Auth para validar o Usuario antes de prosseguir com a Pesquisa
        [HttpPut]
        public ActionResult PutSivecAuth([FromBody]LoginSivec login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var autenticado = scrap.AuthCadesp(login.usuario, login.senha);
            if (autenticado == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        //POST de Dados de extração do Sivec para inserir a Pesquisa
        [HttpPost("{id?}")]
        public ActionResult PostSivec([FromBody]ExtracaoSivec dados, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var extracao = scrap.ScrapingSivec(dados.opcao, dados.rg, dados.nome, dados.matriculaSap, dados.usuario, dados.senha);
                if (extracao == null) { return BadRequest(); }

                if (id != null)
                {
                    var _pesquisa = _db.Pesquisas.SingleOrDefault(x => x.IdPesquisa == int.Parse(id));
                    if (_pesquisa == null) { return BadRequest(); }

                    _pesquisa.Sivec = new Sivec
                    {
                        Alcunha = extracao.Alcunha,
                        Cabelo = extracao.Cabelo,
                        CorOlho = extracao.CorOlho,
                        CorPele = extracao.CorPele,
                        DataEmissao = extracao.DataEmissao,
                        DataNascimento = extracao.DataNascimento,
                        EnderecoResidencial = extracao.EnderecoResidencial,
                        EnderecoTrabalho = extracao.EnderecoTrabalho,
                        EstadoCivil = extracao.EstadoCivil,
                        Formula = extracao.Formula,
                        GrauInstrucao = extracao.GrauInstrucao,
                        Naturalidade = extracao.Naturalidade,
                        Naturalizado = extracao.Naturalizado,
                        Nome = extracao.Nome,
                        NomeMae = extracao.NomeMae,
                        NomePai = extracao.NomePai,
                        Posto = extracao.Posto,
                        Profissao = extracao.Profissao,
                        Rg = extracao.Rg,
                        Sexo = extracao.Sexo,
                        TipoRg = extracao.TipoRg
                    };

                    _db.Pesquisas.Update(_pesquisa);
                    _db.SaveChanges();

                    return Ok(_pesquisa.IdPesquisa);
                }

                var pesquisa = new Pesquisa
                {
                    DataPesquisa = DateTime.Now,
                    Sivec = new Sivec
                    {
                        Alcunha = extracao.Alcunha,
                        Cabelo = extracao.Cabelo,
                        CorOlho = extracao.CorOlho,
                        CorPele = extracao.CorPele,
                        DataEmissao = extracao.DataEmissao,
                        DataNascimento = extracao.DataNascimento,
                        EnderecoResidencial = extracao.EnderecoResidencial,
                        EnderecoTrabalho = extracao.EnderecoTrabalho,
                        EstadoCivil = extracao.EstadoCivil,
                        Formula = extracao.Formula,
                        GrauInstrucao = extracao.GrauInstrucao,
                        Naturalidade = extracao.Naturalidade,
                        Naturalizado = extracao.Naturalizado,
                        Nome = extracao.Nome,
                        NomeMae = extracao.NomeMae,
                        NomePai = extracao.NomePai,
                        Posto = extracao.Posto,
                        Profissao = extracao.Profissao,
                        Rg = extracao.Rg,
                        Sexo = extracao.Sexo,
                        TipoRg = extracao.TipoRg
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
