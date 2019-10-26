using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMPSP.Domain.Models;

namespace ProjetoMPSP.Infrastructure.EntityConfiguration
{
    class SielConfiguration : IEntityTypeConfiguration<Siel>
    {
        public void Configure(EntityTypeBuilder<Siel> builder)
        {
            builder.ToTable("Siel");

            builder.HasKey(x => x.IdPesquisa);

            builder.HasOne(x => x.Pesquisa)
                   .WithOne(x => x.Siel)
                   .HasForeignKey<Siel>(x => x.IdPesquisa)
                   .IsRequired();
        }
    }
}
