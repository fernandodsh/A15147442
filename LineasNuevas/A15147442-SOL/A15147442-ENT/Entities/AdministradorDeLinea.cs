using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class AdministradorDeLinea
    {
        public int AdmiLineaId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Area { get; set; }

        public LineaTelefonica LineaTelefonica { get; set; }

        public int LineaId { get; set; }

        
    }
}
