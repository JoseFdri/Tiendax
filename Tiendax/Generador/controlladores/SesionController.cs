using Generador.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generador.controlladores
{
    class SesionController
    {
        private db_ventasContext db = new db_ventasContext();

        public int iniciar_sesion(string usuario, string password)
        {
            var resultado = db.usuario
                                .Where(x => x.nombre == usuario && x.password == password)
                                .SingleOrDefault();
            if(resultado != null)
            {
                return 1;
            }else
            {
                return 0;
            }
        }
    }
}
