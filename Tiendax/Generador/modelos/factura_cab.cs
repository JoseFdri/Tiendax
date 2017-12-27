namespace Generador.modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class factura_cab
    {
        [Key]
        public int idFacturaCab { get; set; }

        [StringLength(11)]
        public string ruc { get; set; }

        [StringLength(50)]
        public string razon_social { get; set; }

        [StringLength(100)]
        public string direccion { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? fecha { get; set; }
    }
}
