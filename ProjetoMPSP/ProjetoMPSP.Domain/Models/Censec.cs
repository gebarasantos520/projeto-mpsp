using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Domain.Models
{
    public class Censec
    {
        public string Documento { get; set; }
        public string Carga { get; set; }
        public string DataCarga { get; set; }
        public string DataAto { get; set; }
        public string Livro { get; set; }
        public string Folha { get; set; }
        public string Ato { get; set; }
        public int IdPesquisa { get; set; }

        public virtual Pesquisa Pesquisa { get; set; }
    }
}
