using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoMPSP.Domain.Models;

namespace ProjetoMPSP.Infrastructure.EntityConfiguration
{
    class CensecConfiguration : IEntityTypeConfiguration<Censec>
    {
        public void Configure(EntityTypeBuilder<Censec> builder)
        {
        builder.ToTable("Censec");

        builder.HasKey(x => x.IdPesquisa);

        builder.HasOne(x => x.Pesquisa)
               .WithOne(x => x.Censec)
               .HasForeignKey<Censec>(x => x.IdPesquisa)
               .IsRequired();
        }
    }
}
