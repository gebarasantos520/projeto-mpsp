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
    public class DetranController : Controller
    {
        private readonly ScrapingService scrap;
        private readonly MPSPDbContext _db;

        public DetranController(MPSPDbContext db, IConfiguration conf)
        {
            _db = db;
            scrap = new ScrapingService(conf);
        }

        [HttpPut]
        public ActionResult PutAuthDentra([FromBody]AuthDetran login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var autenticado = scrap.AuthDetran(login.logincpf, login.senha, x => x.Dispose());
            if (autenticado == true)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("{id?}")]
        public ActionResult PostDetran([FromBody]ExtracaoDetran dados, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var extracao = scrap.ScrapingDetran(dados.logincpf, dados.senha, dados.option, dados.cpf, dados.placa, dados.nome);
                if (extracao == null) { return BadRequest(); }

                if (id != null)
                {
                    var _pesquisa = _db.Pesquisas.SingleOrDefault(x => x.IdPesquisa == int.Parse(id));
                    if (_pesquisa == null) { return BadRequest(); }

                    if (dados.option == 1 && dados.cpf != null && dados.nome != null)
                    {
                        _pesquisa.Detran = new Detran
                        {
                            DataUploadCondutor = DateTime.Now,
                            CPF = dados.cpf,
                            Nome = dados.nome,
                            NomeOriginalCondutorIMG = extracao.NomeOriginalCondutorIMG,
                            NomeOriginalCondutorPDF = extracao.NomeOriginalCondutorPDF
                        };

                        _db.Pesquisas.Update(_pesquisa);
                        _db.SaveChanges();

                        return Ok(_pesquisa.IdPesquisa);
                    }
                    else if (dados.option == 2 && dados.cpf != null && dados.placa != null)
                    {
                        _pesquisa.Detran = new Detran
                        {
                            DataUploadVeiculo = DateTime.Now,
                            Placa = dados.placa,
                            CPF = dados.cpf,
                            NomeOriginalVeiculo = extracao.NomeOriginalVeiculo
                        };

                        _db.Pesquisas.Update(_pesquisa);
                        _db.SaveChanges();

                        return Ok(_pesquisa.IdPesquisa);
                    }
                    else { return BadRequest(); }

                }

                if (dados.option == 1 && dados.cpf != null && dados.nome != null)
                {
                    var pesquisa = new Pesquisa
                    {
                        DataPesquisa = DateTime.Now,
                        Detran = new Detran
                        {
                            DataUploadCondutor = DateTime.Now,
                            CPF = dados.cpf,
                            Nome = dados.nome,
                            NomeOriginalCondutorIMG = extracao.NomeOriginalCondutorIMG,
                            NomeOriginalCondutorPDF = extracao.NomeOriginalCondutorPDF
                        }
                    };

                    _db.Pesquisas.Add(pesquisa);
                    _db.SaveChanges();

                    return Ok(pesquisa.IdPesquisa);
                }
                else if (dados.option == 2 && dados.cpf != null && dados.placa != null)
                {
                    var pesquisa = new Pesquisa
                    {
                        DataPesquisa = DateTime.Now,
                        Detran = new Detran
                        {
                            DataUploadVeiculo = DateTime.Now,
                            Placa = dados.placa,
                            CPF = dados.cpf,
                            NomeOriginalVeiculo = extracao.NomeOriginalVeiculo
                        }
                    };

                    _db.Pesquisas.Add(pesquisa);
                    _db.SaveChanges();

                    return Ok(pesquisa.IdPesquisa);
                }
                else { return BadRequest(); }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}
