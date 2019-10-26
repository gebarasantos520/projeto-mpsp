using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMPSP.API.ViewModel
{
    public class DetranViewModel
    {
        public string CPF { get; set; }
        public string Placa { get; set; }
        public string Nome { get; set; }
        public string NomeOriginalCondutorPDF { get; set; }
        public string NomeOriginalCondutorIMG { get; set; }
        public string NomeOriginalVeiculo { get; set; }
    }
    public class AuthDetran
    {
        [Required]
        public string logincpf { get; set; }
        [Required]
        public string senha { get; set; }
    }
    public class ExtracaoDetran : AuthDetran
    {
        public int option { get; set; }
        public string nome { get; set; }
        [Required]
        public string cpf { get; set; }
        public string placa { get; set; }
    }
}
