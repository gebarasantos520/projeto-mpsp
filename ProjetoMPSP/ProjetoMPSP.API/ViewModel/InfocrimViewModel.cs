using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMPSP.API.ViewModel
{
    public class InfocrimViewModel
    {
        public int IdInfocrim { get; set; }
        public string NomeOriginal { get; set; }
        public DateTime DataUpload { get; set; }
    }
    public class ExtracaoInfocrim 
    {
        [Required]
        public string usuario { get; set; }
        [Required]
        public string senha { get; set; }
    }
}
