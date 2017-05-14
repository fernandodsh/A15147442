using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class TipoDeLinea
    {
        public int TipoId { get; set; }

        public string Tipo { get; set; }

        public List<LineaTelefonica> LineaTelefonica { get; set; }

        public TipoDeLinea()
        {
            LineaTelefonica = new List<LineaTelefonica>();
        }
    }
}
