using Generador.modelos;
using Generador.utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generador.controlladores
{
    class ProductoController
    {
        private db_ventasContext db = new db_ventasContext();

        public List<producto> buscar_producto( Filtro filtro )
        {
            string limite = "";
            if(filtro.limit != null)
            {
                limite = "TOP " + filtro.limit;
            }
            string sql = "SELECT "+ limite + " * " +
                    " FROM producto "+
                    " WHERE nombre LIKE '%"+filtro.nombre+"%' ";

            if(filtro.idCat != null)
            {
                sql += " AND idCategoria = " + filtro.idCat;
            }
            if(filtro.desc != null)
            {
                sql += " AND descripcion LIKE '%" +filtro.desc+"%' ";
            }
            if(filtro.precioMax != null)
            {
                sql += " AND precio < " + filtro.precioMax;
            }
            if(filtro.precioMin != null)
            {
                sql += " AND precio > " + filtro.precioMin;
            }
            var productos = db.Database.SqlQuery<producto>(sql).ToList();
            return productos;
        }
        public int crearProducto(producto product)
        {
            db.producto.Add(product);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return 1;
        }
        public string generar_codigo()
        {
            int numero = 10;
            var linea = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var longitud = linea.Length;
            int indice;
            string txt = string.Empty;
            Random rnd = new Random();
            string codigo = string.Empty;
            for (var i = 0; i < numero; i++)
            {
                indice = (int)(rnd.NextDouble() * longitud);
                txt = linea.Substring(indice, 1);
                codigo += txt;
            }
            return codigo;
        }
    }
    class Filtro
    {
        public int? idCat = null;
        public string desc = null;
        public string nombre = null;
        public int? precioMax = null;
        public int? precioMin = null;
        public int? limit = null;
    }
}
