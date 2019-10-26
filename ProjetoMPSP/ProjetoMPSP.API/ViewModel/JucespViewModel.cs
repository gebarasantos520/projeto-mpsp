using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMPSP.API.ViewModel
{
    public class JucespViewModel
    {
        public string NomeEmpresa { get; set; }
        public string DataConst { get; set; }
        public string TipoEmpresa { get; set; }
        public string InicioAtividade { get; set; }
        public string Cnpj { get; set; }
        public string Objeto { get; set; }
        public string Capital { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Ficha { get; set; }
        public DateTime? DataUploadFicha { get; set; }
    }

    public class ExtracaoJucesp : JucespViewModel
    {
       [Required]
       public string nomeEmpresa { get; set; }
    }
}
