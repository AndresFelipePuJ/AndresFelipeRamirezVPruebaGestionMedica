using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MicroServicioReceta.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModelRecetas")
        {
        }

        public virtual DbSet<RecetasTb> RecetasTb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecetasTb>()
                .Property(e => e.CodigoReceta)
                .IsUnicode(false);

            modelBuilder.Entity<RecetasTb>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<RecetasTb>()
                .Property(e => e.Estado)
                .IsUnicode(false);
        }
    }
}
