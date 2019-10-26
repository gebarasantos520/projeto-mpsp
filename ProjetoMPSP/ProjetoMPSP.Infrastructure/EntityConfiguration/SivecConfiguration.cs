using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMPSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Infrastructure.EntityConfiguration
{
    public class SivecConfiguration : IEntityTypeConfiguration<Sivec>
    {
        public void Configure(EntityTypeBuilder<Sivec> builder)
        {
            builder.ToTable("Sivec");

            builder.HasKey(x => x.IdPesquisa);

            builder.HasOne(x => x.Pesquisa)
                   .WithOne(x => x.Sivec)
                   .HasForeignKey<Sivec>(x => x.IdPesquisa)
                   .IsRequired();
        }
    }
}
