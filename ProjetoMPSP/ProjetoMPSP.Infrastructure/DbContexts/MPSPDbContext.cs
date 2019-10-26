using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoMPSP.Domain.Models;
using ProjetoMPSP.Infrastructure.EntityConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMPSP.Infrastructure.DbContexts
{
    public class MPSPDbContext : IdentityDbContext<Usuario>
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Arisp> Arisp { get; set; }
        public DbSet<Arpensp> Arpensp { get; set; }
        public DbSet<Cadesp> Cadesp { get; set; }
        public DbSet<Caged> Caged { get; set; }
        public DbSet<Censec> Censec { get; set; }
        public DbSet<Detran> Detran { get; set; }
        public DbSet<Infocrim> Infocrim { get; set; }
        public DbSet<Siel> Siel { get; set; }
        public DbSet<Sivec> Sivec { get; set; }
        public DbSet<Jucesp> Jucesp { get; set; }

        public DbSet<Pesquisa> Pesquisas { get; set; }

        public MPSPDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ArispConfiguration())
                        .ApplyConfiguration(new ArpenspConfiguration())
                        .ApplyConfiguration(new CadespConfiguration())
                        .ApplyConfiguration(new CagedConfiguration())
                        .ApplyConfiguration(new CensecConfiguration())
                        .ApplyConfiguration(new DetranConfiguration())
                        .ApplyConfiguration(new InfocrimConfiguration())
                        .ApplyConfiguration(new SielConfiguration())
                        .ApplyConfiguration(new SivecConfiguration())
                        .ApplyConfiguration(new PesquisaConfiguration())
                        .ApplyConfiguration(new JucespConfiguration());
        }

    }
}
