using Microsoft.AspNetCore.Mvc;
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
    public class CagedController : Controller
    {
        private readonly ScrapingService scrap;
        private readonly MPSPDbContext _db;

        public CagedController(MPSPDbContext db)
        {
            _db = db;
            scrap = new ScrapingService();
        }

        //PUT de Autenticação do Caged
        [HttpPut]
        public ActionResult PutCagedAuth([FromBody]LoginCaged login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var autenticado = scrap.AuthCaged(login.cpf, login.senha);
            if (autenticado == true)
            {
                return Ok();
            }
            return BadRequest();
        }

        //POST de Dados de extração do Caged para inserir a Pesquisa
        [HttpPost("{id?}")]
        public ActionResult PostCaged([FromBody] ExtracaoCaged dados,string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var extracao = scrap.ScrapingCaged(dados.cpf, dados.senha, dados.cnpj , dados.chavePesquisa);
                if (extracao == null) { return BadRequest(); }

                if (id != null)
                {
                    var _pesquisa = _db.Pesquisas.SingleOrDefault(x => x.IdPesquisa == int.Parse(id));
                    if (_pesquisa == null) { return BadRequest(); }

                    _pesquisa.Caged = new Caged
                    {
                        
                        //Responsavel
                        Documento = extracao.DadosCaged.Documento,
                        RazaoSocialNome = extracao.DadosCaged.RazaoSocialNome,
                        Logradouro = extracao.DadosCaged.Logradouro,
                        BairroDistrito = extracao.DadosCaged.Logradouro,
                        Municipio = extracao.DadosCaged.Municipio,
                        UF = extracao.DadosCaged.UF,
                        Cep = extracao.DadosCaged.Cep,
                        Nome = extracao.DadosCaged.Nome,
                        Cpf = extracao.DadosCaged.Cpf,
                        Telefone = extracao.DadosCaged.Telefone,
                        Ramal = extracao.DadosCaged.Ramal,
                        Email = extracao.DadosCaged.Email,

                        //Empresa
                        CnpjRaiz = extracao.Empresa.CnpjRaiz,
                        RazaoSocial = extracao.Empresa.RazaoSocial,
                        AtividadeEconomica = extracao.Empresa.AtividadeEconomica,
                        NumeroFiliais = extracao.Empresa.NumeroFiliais,
                        Admissoes = extracao.Empresa.Admissoes,
                        TotalVinculos = extracao.Empresa.TotalVinculos,
                        PrimeiroDia = extracao.Empresa.PrimeiroDia,
                        Desligamentos = extracao.Empresa.Desligamentos,
                        UltimoDia = extracao.Empresa.UltimoDia,
                        VariacaoAbsoluta = extracao.Empresa.VariacaoAbsoluta,

                        //Trabalhador
                        NomeTrabalhador = extracao.Trabalhador.Nome,
                        PisBase = extracao.Trabalhador.PisBase,
                        CpfTrabalhador = extracao.Trabalhador.Cpf,
                        DataNascimento = extracao.Trabalhador.DataNascimento,
                        Ctps = extracao.Trabalhador.Ctps,
                        Situacao = extracao.Trabalhador.Situacao,
                        Nacionalidade = extracao.Trabalhador.Nacionalidade,
                        GrauInstrucao = extracao.Trabalhador.GrauInstrucao,
                        Deficiencia = extracao.Trabalhador.Deficiencia,
                        Sexo = extracao.Trabalhador.Sexo,
                        Raca = extracao.Trabalhador.Raca,
                        TempoTrabalho = extracao.Trabalhador.TempoTrabalho
                    };

                    _db.Pesquisas.Update(_pesquisa);
                    _db.SaveChanges();

                    return Ok(_pesquisa.IdPesquisa);
                }

                var pesquisa = new Pesquisa
                {
                    DataPesquisa = DateTime.Now,
                    Caged = new Caged
                    {
                        //Responsavel
                        Documento = extracao.DadosCaged.Documento,
                        RazaoSocialNome = extracao.DadosCaged.RazaoSocialNome,
                        Logradouro = extracao.DadosCaged.Logradouro,
                        BairroDistrito = extracao.DadosCaged.Logradouro,
                        Municipio = extracao.DadosCaged.Municipio,
                        UF = extracao.DadosCaged.UF,
                        Cep = extracao.DadosCaged.Cep,
                        Nome = extracao.DadosCaged.Nome,
                        Cpf = extracao.DadosCaged.Cpf,
                        Telefone = extracao.DadosCaged.Telefone,
                        Ramal = extracao.DadosCaged.Ramal,
                        Email = extracao.DadosCaged.Email,

                        //Empresa
                        CnpjRaiz = extracao.Empresa.CnpjRaiz,
                        RazaoSocial = extracao.Empresa.RazaoSocial,
                        AtividadeEconomica = extracao.Empresa.AtividadeEconomica,
                        NumeroFiliais = extracao.Empresa.NumeroFiliais,
                        Admissoes = extracao.Empresa.Admissoes,
                        TotalVinculos = extracao.Empresa.TotalVinculos,
                        PrimeiroDia = extracao.Empresa.PrimeiroDia,
                        Desligamentos = extracao.Empresa.Desligamentos,
                        UltimoDia = extracao.Empresa.UltimoDia,
                        VariacaoAbsoluta = extracao.Empresa.VariacaoAbsoluta,

                        //Trabalhador
                        NomeTrabalhador = extracao.Trabalhador.Nome,
                        PisBase = extracao.Trabalhador.PisBase,
                        CpfTrabalhador = extracao.Trabalhador.Cpf,
                        DataNascimento = extracao.Trabalhador.DataNascimento,
                        Ctps = extracao.Trabalhador.Ctps,
                        Situacao = extracao.Trabalhador.Situacao,
                        Nacionalidade = extracao.Trabalhador.Nacionalidade,
                        GrauInstrucao = extracao.Trabalhador.GrauInstrucao,
                        Deficiencia = extracao.Trabalhador.Deficiencia,
                        Sexo = extracao.Trabalhador.Sexo,
                        Raca = extracao.Trabalhador.Raca,
                        TempoTrabalho = extracao.Trabalhador.TempoTrabalho
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
