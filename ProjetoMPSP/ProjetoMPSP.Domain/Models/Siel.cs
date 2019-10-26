using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Domain.Models
{
    public class Siel
    {
        public string Nome { get; set; }
        public string Zona { get; set; }
        public string Endereco { get; set; }
        public string DataNascimento { get; set; }
        public string NumeroProcesso { get; set; }
        public string Titulo { get; set; }
        public string Municipio { get; set; }
        public string Uf { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string Naturalidade { get; set; }
        public string CodigoValidacao { get; set; }
        public DateTime DataDomicilio { get; set; }

        public int IdPesquisa { get; set; }

        public virtual Pesquisa Pesquisa { get; set; }
    }
}
