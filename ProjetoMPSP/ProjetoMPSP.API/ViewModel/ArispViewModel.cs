using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMPSP.API.ViewModel
{
    public class ArispViewModel
    {
        public int IdArisp { get; set; }
        public string NomeOriginal { get; set; }
        public string Nome { get; set; }
        public DateTime DataUpload { get; set; }
        public string Documento { get; set; }

    }

    public class ExtracaoArisp
    {
        [Required]
        public string documento { get; set; }
    }
}
