using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class CentroDeAtencion
    {
        public int CentroId { get; set; }

        public string Centro { get; set; }

        public Direccion Direccion { get; set; }

    }
}
