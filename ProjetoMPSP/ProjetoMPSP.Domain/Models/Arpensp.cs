using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Domain.Models
{
    public class Arpensp
    {
        public string NumeroProcesso { get; set; }
        public string CartorioRegistro { get; set; }
        public string numeroCNS { get; set; }
        public string UF { get; set; }
        public string NomeConjuge1 { get; set; }
        public string NomeNovoConjuge1 { get; set; }
        public string NomeConjuge2 { get; set; }
        public string NomeNovoConjuge2 { get; set; }
        public DateTime DataCasamento { get; set; }
        public string Matricula { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Acervo { get; set; }
        public string NumeroLivro { get; set; }
        public string NumeroFolha { get; set; }
        public string NumeroRegistro { get; set; }
        public string TipoLivro { get; set; }

        public int IdPesquisa { get; set; }

        public virtual Pesquisa Pesquisa { get; set; }
    }
}
