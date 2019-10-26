using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMPSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Infrastructure.EntityConfiguration
{
    class DetranConfiguration : IEntityTypeConfiguration<Detran>
    {
        public void Configure(EntityTypeBuilder<Detran> builder)
        {
            builder.ToTable("Detran");

            builder.HasKey(x => x.IdPesquisa);

            builder.HasOne(x => x.Pesquisa)
                   .WithOne(x => x.Detran)
                   .HasForeignKey<Detran>(x => x.IdPesquisa)
                   .IsRequired();
        }
    }
}
