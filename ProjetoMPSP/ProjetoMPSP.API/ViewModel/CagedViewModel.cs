using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMPSP.API.ViewModel
{
    public class CagedViewModel
    {
        public DadosCaged DadosCaged { get; set; }
        public Empresa Empresa { get; set; }
        public Trabalhador Trabalhador { get; set; }
    }
    public class DadosCaged
    {
        public string Documento { get; set; }
        public string RazaoSocialNome { get; set; }
        public string Logradouro { get; set; }
        public string BairroDistrito { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string Cep { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Ramal { get; set; }
        public string Email { get; set; }
    }

    public class Trabalhador
    {
        public string Nome { get; set; }
        public string PisBase { get; set; }
        public string Cpf { get; set; }
        public string Ctps { get; set; }
        public string Situacao { get; set; }
        public string Nacionalidade { get; set; }
        public string GrauInstrucao { get; set; }
        public string Deficiencia { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Raca { get; set; }
        public string TempoTrabalho { get; set; }
    }

    public class Empresa
    {
        public string CnpjRaiz { get; set; }
        public string RazaoSocial { get; set; }
        public string AtividadeEconomica { get; set; }
        public string NumeroFiliais { get; set; }
        public string Admissoes { get; set; }
        public string VariacaoAbsoluta { get; set; }
        public string TotalVinculos { get; set; }
        public string Desligamentos { get; set; }
        public string PrimeiroDia { get; set; }
        public string UltimoDia { get; set; }

    }

    public class LoginCaged
    {
        [Required]
        public string cpf { get; set; }
        [Required]
        public string senha { get; set; }
    }

    public class ExtracaoCaged : LoginCaged
    {
        [Required]
        public string cnpj { get; set; }
        [Required]
        public string chavePesquisa { get; set; }
    }

   
}
