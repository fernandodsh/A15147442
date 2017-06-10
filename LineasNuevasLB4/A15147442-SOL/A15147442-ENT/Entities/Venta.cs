using A15147442_ENT.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class Venta
    {
        public int VentaId { get; set; }

        public string Encargado { get; set; }

        public DateTime FechaVendida { get; set; }

        public TipoDePago TipoDePago { get; set; }

        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }

      
    }
}
