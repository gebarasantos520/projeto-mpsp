using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Domain.Models
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
    }
}
