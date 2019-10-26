using System;

namespace ProjetoMPSP.API.ViewModel
{
    public class ArpenspViewModel
    {
        public string CartorioRegistro { get; set; }
        public string NumeroCNS { get; set; }
        public string UF { get; set; }
        public string NomeConjuge1 { get; set; }
        public string NomeNovoConjuge1 { get; set; }
        public string NomeConjuge2 { get; set; }
        public string NomeNovoConjuge2 { get; set; }
        public string DataCasamento { get; set; }
        public string Matricula { get; set; }
        public string DataEntrada { get; set; }
        public string DataRegistro { get; set; }
        public string Acervo { get; set; }
        public string NumeroLivro { get; set; }
        public string NumeroFolha { get; set; }
        public string NumeroRegistro { get; set; }
        public string TipoLivro { get; set; }
    }

    public class ExtracaoArpensp
    {
        public string numeroProcesso { get; set; }
    }
}
