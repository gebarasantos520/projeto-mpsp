using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Domain.Models
{
    public class Arisp
    {
        public int IdArisp  { get; set; }
        public string NomeOriginal { get; set; }
        public DateTime DataUpload { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }

        public int IdPesquisa { get; set; }

        public virtual Pesquisa Pesquisa { get; set; }
    }
}
