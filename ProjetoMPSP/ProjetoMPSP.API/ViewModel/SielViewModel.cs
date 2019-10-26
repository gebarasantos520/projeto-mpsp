using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMPSP.API.ViewModel
{
    public class SielViewModel
    {
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string DataNascimento { get; set; }
        public string Zona { get; set; }
        public string Endereco { get; set; }
        public string Municipio { get; set; }
        public string UF { get; set; }
        public string DataDomicilio { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string Naturalidade { get; set; }
        public string CodigoValidacao { get; set; }
    }
    public class LoginSiel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string email { get; set; }
        [Required]
        public string senha { get; set; }
    }

    public class ExtracaoSiel : LoginSiel
    {
        [Required]
        public string nome { get; set; }
        [Required]
        public string numeroProcesso { get; set; }
    }
}
