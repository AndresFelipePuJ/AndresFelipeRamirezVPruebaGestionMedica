using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MSPersona.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModeloPersona")
        {
        }

        public virtual DbSet<PersonasTb> PersonasTb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonasTb>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PersonasTb>()
                .Property(e => e.DocumentoId)
                .IsUnicode(false);

            modelBuilder.Entity<PersonasTb>()
                .Property(e => e.TipoPersona)
                .IsUnicode(false);
        }
    }
}
