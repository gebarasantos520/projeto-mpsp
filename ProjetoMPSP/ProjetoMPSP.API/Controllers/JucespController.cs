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
    public class JucespController : Controller
    {
        private readonly ScrapingService scrap;
        private readonly MPSPDbContext _db;

        public JucespController(MPSPDbContext db)
        {
            _db = db;
            scrap = new ScrapingService();
        }

        //POST de Dados de extração do Arisp para inserir a Pesquisa
        [HttpPost("{id?}")]
        public ActionResult PostJucesp([FromBody]ExtracaoJucesp dados, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var extracao = scrap.ScrapingJucesp(dados.nomeEmpresa);
                if (extracao == null) { return BadRequest(); }

                if (id != null)
                {
                    var _pesquisa = _db.Pesquisas.SingleOrDefault(x => x.IdPesquisa == int.Parse(id));
                    if (_pesquisa == null) { return BadRequest(); }

                    _pesquisa.Jucesp = new Jucesp
                    {
                        Bairro = extracao.Bairro,
                        Capital = extracao.Capital,
                        Cep = extracao.Cep,
                        Cnpj = extracao.Cnpj,
                        Complemento = extracao.Complemento,
                        DataConst = extracao.DataConst,
                        DataUploadFicha = DateTime.Now,
                        Ficha = extracao.Ficha,
                        InicioAtividade = extracao.InicioAtividade,
                        Logradouro = extracao.Logradouro,
                        Municipio = extracao.Municipio,
                        NomeEmpresa = extracao.NomeEmpresa,
                        Numero = extracao.Numero,
                        Objeto = extracao.Objeto,
                        TipoEmpresa = extracao.TipoEmpresa,
                        Uf = extracao.Uf
                    };

                    _db.Pesquisas.Update(_pesquisa);
                    _db.SaveChanges();

                    return Ok(_pesquisa.IdPesquisa);
                }

                var pesquisa = new Pesquisa
                {
                    DataPesquisa = DateTime.Now,
                    Jucesp = new Jucesp
                    {
                        Bairro = extracao.Bairro,
                        Capital = extracao.Capital,
                        Cep = extracao.Cep,
                        Cnpj = extracao.Cnpj,
                        Complemento = extracao.Complemento,
                        DataConst = extracao.DataConst,
                        DataUploadFicha = extracao.DataUploadFicha,
                        Ficha = extracao.Ficha,
                        InicioAtividade = extracao.InicioAtividade,
                        Logradouro = extracao.Logradouro,
                        Municipio = extracao.Municipio,
                        NomeEmpresa = extracao.NomeEmpresa,
                        Numero = extracao.Numero,
                        Objeto = extracao.Objeto,
                        TipoEmpresa = extracao.TipoEmpresa,
                        Uf = extracao.Uf
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
