using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Domain.Models
{
    public class Sivec
    {
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Rg { get; set; } 
        public string TipoRg { get; set; }
        public string DataEmissao { get; set; }
        public string EstadoCivil { get; set; } 
        public string Naturalizado { get; set; }
        public string GrauInstrucao { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string CorPele { get; set; }
        public string Alcunha { get; set; }
        public string Naturalidade { get; set; }
        public string Posto { get; set; }
        public string Formula { get; set; }
        public string CorOlho { get; set; }
        public string Cabelo { get; set; }
        public string Profissao { get; set; }
        public string EnderecoResidencial { get; set; }
        public string EnderecoTrabalho { get; set; }

        public int IdPesquisa { get; set; }
        public virtual Pesquisa Pesquisa { get; set; }
    }
}
