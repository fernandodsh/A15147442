using A15147442_ENT.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class LineaTelefonica
    {
        public int LineaId { get; set; }

        public string Descripcion { get; set; }

        public TipoDeLinea TipoDeLinea { get; set; }

        public List<Evaluacion> Evaluacion { get; set; }

        public LineaTelefonica()
        {
            Evaluacion = new List<Evaluacion>();
        }
    }
}
