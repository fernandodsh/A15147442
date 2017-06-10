using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class Direccion
    {
        public int DireccionId { get; set; }

        public string Descripcion { get; set; }

        public CentroDeAtencion CentroDeAtencion { get; set; }

    }
}
