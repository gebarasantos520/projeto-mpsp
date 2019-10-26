using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMPSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Infrastructure.EntityConfiguration
{
    class InfocrimConfiguration : IEntityTypeConfiguration<Infocrim>
    {
        public void Configure(EntityTypeBuilder<Infocrim> builder)
        {
            builder.ToTable("Infocrim");

            builder.HasKey(x => x.IdPesquisa);

            builder.HasOne(x => x.Pesquisa)
                   .WithOne(x => x.Infocrim)
                   .HasForeignKey<Infocrim>(x => x.IdPesquisa)
                   .IsRequired();
        }

    }
}
