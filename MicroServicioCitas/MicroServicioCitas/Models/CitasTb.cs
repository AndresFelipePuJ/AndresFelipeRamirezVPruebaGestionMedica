namespace MicroServicioCitas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CitasTb")]
    public partial class CitasTb
    {
        [Key]
        public int CitasId { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(20)]
        public string Lugar { get; set; }

        public int PacienteId { get; set; }

        public int MedicoId { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; }

        [Column(TypeName = "text")]
        public string Observaciones { get; set; }
    }
}
