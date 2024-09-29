namespace MSPersona.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonasTb")]
    public partial class PersonasTb
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string DocumentoId { get; set; }

        public int Edad { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoPersona { get; set; }
    }
}
