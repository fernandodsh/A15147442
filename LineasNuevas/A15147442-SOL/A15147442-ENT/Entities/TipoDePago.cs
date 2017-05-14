using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class TipoDePago
    {
        public int TipoPagoId { get; set; }

        public string Tipo { get; set; }

        public double Monto { get; set; }

        public List<Venta> Venta { get; set; }

        public TipoDePago()
        {
            Venta = new List<Venta>();
        }
    }
}
