using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class EstadoDeEvaluacion
    {
        public int EstadoId { get; set; }

        public string Estado { get; set; }

        public string Descripcion { get; set; }

        public List<Evaluacion> Evaluacion { get; set; }

        public EstadoDeEvaluacion()
        {
            Evaluacion = new List<Evaluacion>();
        }
    }
}
