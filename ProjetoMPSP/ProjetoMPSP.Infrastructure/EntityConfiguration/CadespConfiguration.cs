using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMPSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Infrastructure.EntityConfiguration
{
    public class CadespConfiguration : IEntityTypeConfiguration<Cadesp>
    {
        public void Configure(EntityTypeBuilder<Cadesp> builder)
        {
            builder.ToTable("Cadesp");

            builder.HasKey(x => x.IdPesquisa);

            builder.HasOne(x => x.Pesquisa)
                   .WithOne(x => x.Cadesp)
                   .HasForeignKey<Cadesp>(x => x.IdPesquisa)
                   .IsRequired();
        }
    }
}
