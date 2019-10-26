using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Domain.Models
{
    public class Pesquisa
    {
        public int IdPesquisa { get; set; }
        public DateTime DataPesquisa { get; set; }


        public ICollection<Arisp> Arisp { get; set; }
        public virtual Arpensp Arpensp { get; set; }
        public virtual Cadesp Cadesp { get; set; }
        public virtual Caged Caged { get; set; }
        public virtual Censec Censec { get; set; }
        public virtual Detran Detran { get; set; }
        public virtual Infocrim Infocrim { get; set; }
        public virtual Siel Siel { get; set; }
        public virtual Sivec Sivec { get; set; }
        public virtual Jucesp Jucesp { get; set; }

    }
}
