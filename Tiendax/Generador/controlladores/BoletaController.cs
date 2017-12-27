using Generador.modelos;
using Generador.utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generador.controlladores
{
    class BoletaController
    {
        private db_ventasContext db = new db_ventasContext();

        public int crear_boleta(boleta_cab bolet_cab, List<ProductoDetalle> detalle)
        {
            int rsp = 1;
            db.boleta_cab.Add(bolet_cab);
            db.SaveChanges();
            var productos = db.producto.ToList();

            foreach (var item in detalle)
            {
                boleta_det bole_det = new boleta_det();
                bole_det.cantidad = item.cantidad;
                bole_det.idBoletaCab = bolet_cab.idBoletaCab;
                bole_det.idProducto = productos
                                        .Where(x => x.codigo == item.codigo)
                                        .Select(x => x.idProducto)
                                        .Single();
                db.boleta_det.Add(bole_det);
            }
            db.SaveChanges();
            return rsp;
        }
    }
}
