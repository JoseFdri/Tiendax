namespace Generador.modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class boleta_cab
    {
        [Key]
        public int idBoletaCab { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string direccion { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? fecha { get; set; }
    }
}
