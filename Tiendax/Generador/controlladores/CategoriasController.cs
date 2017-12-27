using Generador.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generador.controlladores
{
    class CategoriasController
    {
        private db_ventasContext db = new db_ventasContext();

        public List<categoria> listar_categorias()
        {
            return db.categoria.ToList();
        }
    }
}
