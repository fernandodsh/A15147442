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

        public string NombreDelCentro { get; set; }

        public Direccion Direccion { get; set; }

        public int DireccionId { get; set; }

        public List<Venta> Venta { get; set; }

        public List<Evaluacion> Evaluacion { get; set; }

        public CentroDeAtencion()
        {
            Venta = new List<Venta>();
            Evaluacion = new List<Evaluacion>();
        }



    }
}
