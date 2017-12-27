using Generador.modelos;
using Generador.utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generador.controlladores
{
    class FacturaController
    {
        private db_ventasContext db = new db_ventasContext();

        public int crear_factura(factura_cab factura_cab, List<ProductoDetalle> detalle )
        {
            int rsp = 1;
            db.factura_cab.Add(factura_cab);
            db.SaveChanges();
            var productos = db.producto.ToList();

            foreach (var item in detalle)
            {
                factura_det fact_det = new factura_det();
                fact_det.cantidad = item.cantidad;
                fact_det.idFacturaCab = factura_cab.idFacturaCab;
                fact_det.idProducto = productos
                                        .Where(x => x.codigo == item.codigo)
                                        .Select(x => x.idProducto)
                                        .Single();
                db.factura_det.Add(fact_det);
            }
            db.SaveChanges();
            return rsp;
        }
    }
}
