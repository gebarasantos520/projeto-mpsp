using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMPSP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Infrastructure.EntityConfiguration
{
    public class CagedConfiguration : IEntityTypeConfiguration<Caged>
    {
        public void Configure(EntityTypeBuilder<Caged> builder)
        {
            builder.ToTable("Caged");

            builder.HasKey(x => x.IdPesquisa);

            builder.HasOne(x => x.Pesquisa)
                   .WithOne(x => x.Caged)
                   .HasForeignKey<Caged>(x => x.IdPesquisa)
                   .IsRequired();
        }
    }
}
