using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MicroServicioCitas.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModelCitas")
        {
        }

        public virtual DbSet<CitasTb> CitasTb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CitasTb>()
                .Property(e => e.Lugar)
                .IsUnicode(false);

            modelBuilder.Entity<CitasTb>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<CitasTb>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);
        }
    }
}
