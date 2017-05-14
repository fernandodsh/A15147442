using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class TipoDeEvaluacion
    {
        public int TipoEvaluacionId { get; set; }

        public string Tipo { get; set; }

        public List<Evaluacion> Evaluacion { get; set; }

        public TipoDeEvaluacion()
        {
            Evaluacion = new List<Evaluacion>();
        }

    }
}
