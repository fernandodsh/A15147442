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

        public string Direcciones { get; set; }

        public Ubigeo Ubigeo { get; set; }

        public int UbigeoId { get; set; }

        public List<CentroDeAtencion> CentroDeAtencion { get; set; }

        public Direccion()
        {
            CentroDeAtencion = new List<CentroDeAtencion>();

        }

    }
}
