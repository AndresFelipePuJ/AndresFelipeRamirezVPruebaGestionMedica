namespace MicroServicioReceta.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RecetasTb")]
    public partial class RecetasTb
    {
        [Key]
        public int RecetasId { get; set; }

        [Required]
        [StringLength(50)]
        public string CodigoReceta { get; set; }

        public int PacienteId { get; set; }

        public int MedicoId { get; set; }

        public DateTime Fecha { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; }
    }
}
