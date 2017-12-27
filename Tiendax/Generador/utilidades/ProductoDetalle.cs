using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generador.utilidades
{
    public class ProductoDetalle
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string categoria { get; set; }
        public decimal? precio { get; set; }
        public int cantidad { get; set; }
    }
}
