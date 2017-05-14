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

        public Contrato Contrato { get; set; }

        public int ContratoId { get; set; }

        public TipoDePago TipoDePago { get; set; }

        public int TipoPagoId { get; set; }

        public LineaTelefonica LineaTelefonica { get; set; }

        public int LineaId { get; set; }

      
        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }

        public List<CentroDeAtencion> CentroAtencion { get; set; }

        public Venta()
        {
            CentroAtencion = new List<CentroDeAtencion>();
        }

    }
}
