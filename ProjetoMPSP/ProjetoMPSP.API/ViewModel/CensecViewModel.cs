using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMPSP.API.ViewModel
{
    public class CensecViewModel
    {
        public string Carga { get; set; }
        public string Ato { get; set; }
        public string Livro { get; set; }
        public string DiaAto { get; set; }
        public string MesAto { get; set; }
        public string AnoAto { get; set; }
        public string MesCarga { get; set; }
        public string AnoCarga { get; set; }
        public string Folha { get; set; }

    }
    public class LoginCensec
    {
        [Required]
        public string login { get; set; }
        [Required]
        public string senha { get; set; }
    }

    public class ExtracaoCensec : LoginCensec
    {
        [Required]
        public string documento { get; set; }
    }
}
