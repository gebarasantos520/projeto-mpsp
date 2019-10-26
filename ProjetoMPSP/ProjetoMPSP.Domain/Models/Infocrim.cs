using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Domain.Models
{
    public class Infocrim
    {
        public string NomeOriginal { get; set; }
        public DateTime DataUpload { get; set; }

        public int IdPesquisa { get; set; }

        public virtual Pesquisa Pesquisa { get; set; }
    }
}
