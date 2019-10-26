using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Domain.Models
{
    public class Cadesp
    {
        public string IE { get; set; }
        public string CNPJ { get; set; }
        public string NomeEmpresarial { get; set; }
        public string DRT { get; set; }
        public string Situacao { get; set; }      
        public DateTime DataInscricaoEstado { get; set; }
        public string RegimeEstadual { get; set; }
        public string PostoFiscal { get; set; }
        public string NomeFantasia { get; set; }
        public string NIRE { get; set; }
        public string SituacaoCadastral { get; set; }
        public string OcorrenciaFiscal { get; set; }
        public string TipoUnidade { get; set; }
        public DateTime DataIE { get; set; }
        public DateTime DataInicioSituacao { get; set; }

        public int IdPesquisa { get; set; }

        public virtual Pesquisa Pesquisa { get; set; }
    }
}
