using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Domain.Models
{
    public class Detran
    {
        public string NomeOriginalVeiculo { get; set; }
        public DateTime? DataUploadVeiculo { get; set; }
        public string NomeOriginalCondutorPDF { get; set; }
        public string NomeOriginalCondutorIMG { get; set; }
        public DateTime? DataUploadCondutor { get; set; }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Placa { get; set; }

        public int IdPesquisa { get; set; }

        public virtual Pesquisa Pesquisa { get; set; }
    }
}
