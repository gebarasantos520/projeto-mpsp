using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMPSP.API.ViewModel
{
    public class CadespViewModel
    {
        public string Situacao { get; set; }
        public string RegimeEstadual { get; set; }
        public string DRT { get; set; }
        public string PostoFiscal { get; set; }
        public string IE { get; set; }
        public string CNPJ { get; set; }
        public string NomeEmpresarial { get; set; }
        public string NomeFantasia { get; set; }
        public string DataInscricaoEstado { get; set; }
        public string DataInicioSituacao { get; set; }
        public string DataIE { get; set; }
        public string NIRE { get; set; }
        public string SituacaoCadastral { get; set; }
        public string OcorrenciaFiscal { get; set; }
        public string TipoUnidade { get; set; }
        public string InicioIE { get; set; }
        public string InicioSituacao { get; set; }
        public string FormaAtuacao { get; set; }
    }
    public class LoginCadesp
    {
        [Required]
        public string login { get; set; }
        [Required]
        public string senha { get; set; }
    }
    public class ExtracaoCadesp : LoginCadesp
    {
        [Required]
        public string cnpj { get; set; }
    }
}
