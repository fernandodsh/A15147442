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

        public int TipoId  { get; set; }

        public List<Venta> Venta { get; set; }

        public List<AdministradorDeLinea> AdministradorDeLinea { get; set; }

        public List<Evaluacion> Evaluacion { get; set; }

        public LineaTelefonica()
        {
            Venta = new List<Venta>();
            AdministradorDeLinea = new List<AdministradorDeLinea>();
            Evaluacion = new List<Evaluacion>();
        }
    }
}
