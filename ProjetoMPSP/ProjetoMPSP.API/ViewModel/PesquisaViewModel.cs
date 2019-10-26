using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMPSP.API.ViewModel
{
    public class PesquisaViewModel
    {
        public int idpesquisa { get; set; }
        public DateTime datapesquisa { get; set; }
        public bool Arisp { get; set; }
        public bool Arpensp { get; set; }
        public bool Cadesp { get; set; }
        public bool Caged { get; set; }
        public bool Censec { get; set; }
        public bool Detran { get; set; }
        public bool Infocrim { get; set; }
        public bool Jucesp { get; set; }
        public bool Siel { get; set; }
        public bool Sivec { get; set; }
    }
}
