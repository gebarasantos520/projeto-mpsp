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
    public class CadespController : Controller
    {
        private readonly ScrapingService scrap;
        private readonly MPSPDbContext _db;

        public CadespController(MPSPDbContext db)
        {
            _db = db;
            scrap = new ScrapingService();
        }

        //PUT de Auth para validar o Usuario antes de prosseguir com a Pesquisa
        [HttpPut]
        public ActionResult PutCadespAuth([FromBody]LoginCadesp login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var autenticado = scrap.AuthCadesp(login.login, login.senha, x => x.Dispose());
            if (autenticado == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        //POST de Dados de extração do Cadesp para inserir a Pesquisa
        [HttpPost("{id?}")]
        public ActionResult PostCadesp([FromBody]ExtracaoCadesp dados, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var extracao = scrap.ScrapingCadesp(dados.cnpj, dados.login, dados.senha);
                if (extracao == null) { return BadRequest(); }

                if (id != null)
                {
                    var _pesquisa = _db.Pesquisas.SingleOrDefault(x => x.IdPesquisa == int.Parse(id));
                    if (_pesquisa == null){ return BadRequest(); }

                    _pesquisa.Cadesp = new Cadesp
                    {
                        CNPJ = extracao.CNPJ,
                        DataInscricaoEstado = DateTime.Parse(extracao.DataInscricaoEstado).Date,
                        DRT = extracao.DRT,
                        IE = extracao.IE,
                        NIRE = extracao.NIRE,
                        NomeEmpresarial = extracao.NomeEmpresarial,
                        NomeFantasia = extracao.NomeFantasia,
                        OcorrenciaFiscal = extracao.OcorrenciaFiscal,
                        PostoFiscal = extracao.PostoFiscal,
                        RegimeEstadual = extracao.RegimeEstadual,
                        Situacao = extracao.Situacao,
                        SituacaoCadastral = extracao.SituacaoCadastral,
                        TipoUnidade = extracao.TipoUnidade,
                        DataInicioSituacao = DateTime.Parse(extracao.InicioSituacao).Date,
                        DataIE = DateTime.Parse(extracao.InicioIE)
                    };

                    _db.Pesquisas.Update(_pesquisa);
                    _db.SaveChanges();

                    return Ok(_pesquisa.IdPesquisa);
                }

                var pesquisa = new Pesquisa
                {
                    DataPesquisa = DateTime.Now,
                    Cadesp = new Cadesp
                    {
                        CNPJ = extracao.CNPJ,
                        DataInscricaoEstado = DateTime.Parse(extracao.DataInscricaoEstado).Date,
                        DRT = extracao.DRT,
                        IE = extracao.IE,
                        NIRE = extracao.NIRE,
                        NomeEmpresarial = extracao.NomeEmpresarial,
                        NomeFantasia = extracao.NomeFantasia,
                        OcorrenciaFiscal = extracao.OcorrenciaFiscal,
                        PostoFiscal = extracao.PostoFiscal,
                        RegimeEstadual = extracao.RegimeEstadual,
                        Situacao = extracao.Situacao,
                        SituacaoCadastral = extracao.SituacaoCadastral,
                        TipoUnidade = extracao.TipoUnidade,
                        DataInicioSituacao = DateTime.Parse(extracao.DataInicioSituacao).Date,
                        DataIE = DateTime.Parse(extracao.DataInscricaoEstado).Date
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
