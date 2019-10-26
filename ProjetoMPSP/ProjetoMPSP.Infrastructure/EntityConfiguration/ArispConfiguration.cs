using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMPSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Infrastructure.EntityConfiguration
{
    public class ArispConfiguration : IEntityTypeConfiguration<Arisp>
    {
        public void Configure(EntityTypeBuilder<Arisp> builder)
        {
            builder.ToTable("Arisp");

            builder.HasKey(x => new { x.IdPesquisa, x.IdArisp });

            builder.HasOne(x => x.Pesquisa)
                   .WithMany(x => x.Arisp)
                   .HasForeignKey(x => x.IdPesquisa)
                   .IsRequired();
        }
    }
}
