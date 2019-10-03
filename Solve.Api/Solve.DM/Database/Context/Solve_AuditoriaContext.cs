using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Solve.DM.Database
{
    public partial class Solve_AuditoriaContext : DbContext
    {
        public Solve_AuditoriaContext()
        {
        }

        public Solve_AuditoriaContext(DbContextOptions<Solve_AuditoriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auditoria> Auditoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Auditoria>(entity =>
            {
                entity.HasKey(e => e.IdAuditoria)
                    .HasName("PK__Auditori__7FD13FA0D195AFCB");

                entity.Property(e => e.Ejecutor)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEjecucion).HasColumnType("datetime");
            });
        }
    }
}
