namespace Generador.modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class boleta_det
    {
        [Key]
        public int idBoletaDet { get; set; }

        public int? idBoletaCab { get; set; }
        
        public int? idProducto { get; set; }

        public int? cantidad { get; set; }
    }
}
