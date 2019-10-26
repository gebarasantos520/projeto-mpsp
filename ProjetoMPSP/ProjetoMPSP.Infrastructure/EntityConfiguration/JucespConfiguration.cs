using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMPSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Infrastructure.EntityConfiguration
{
    class JucespConfiguration : IEntityTypeConfiguration<Jucesp>
    {
        public void Configure(EntityTypeBuilder<Jucesp> builder)
        {
            builder.ToTable("Jucesp");

            builder.HasKey(x => x.IdPesquisa);

            builder.HasOne(x => x.Pesquisa)
                   .WithOne(x => x.Jucesp)
                   .HasForeignKey<Jucesp>(x => x.IdPesquisa)
                   .IsRequired();
        }

    }
}
