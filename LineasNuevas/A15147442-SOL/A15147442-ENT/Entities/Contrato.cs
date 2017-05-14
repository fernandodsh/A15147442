using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class Contrato
    {
        public int ContratoId { get; set; }

        public string Contratos { get; set; }

        public DateTime Fecha { get; set; }

        public List<Venta> Venta { get; set; }

        public Contrato()
        {
            Venta = new List<Venta>();
        }


    }
}
