using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrossEventos.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrossEventos.Persistence.Contexto
{
    public class CrossEventosContext : DbContext
    {
        public CrossEventosContext(DbContextOptions<CrossEventosContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Promotor> Promotores { get; set; }
        public DbSet<PromotorEvento> PromotoresEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PromotorEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PromotorId});

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);   

            modelBuilder.Entity<Promotor>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Promotor)
                .OnDelete(DeleteBehavior.Cascade);   
        }
    }
}