using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMPSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Infrastructure.EntityConfiguration
{
    public class PesquisaConfiguration : IEntityTypeConfiguration<Pesquisa>
    {
        public void Configure(EntityTypeBuilder<Pesquisa> builder)
        {
            builder.ToTable("Pesquisas");

            builder.HasKey(x => x.IdPesquisa);

        }
    }
}
