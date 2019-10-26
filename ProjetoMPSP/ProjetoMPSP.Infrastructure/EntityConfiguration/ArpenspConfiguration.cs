using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMPSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Infrastructure.EntityConfiguration
{
    public class ArpenspConfiguration : IEntityTypeConfiguration<Arpensp>
    {
        public void Configure(EntityTypeBuilder<Arpensp> builder)
        {
            builder.ToTable("Arpensp");

            builder.HasKey(x => x.IdPesquisa);

            builder.HasOne(x => x.Pesquisa)
                   .WithOne(x => x.Arpensp)
                   .HasForeignKey<Arpensp>(x => x.IdPesquisa)
                   .IsRequired();
        }
    }
}
