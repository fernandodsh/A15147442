using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int DNI { get; set; }

        public string Correo { get; set; }

        public int Edad { get; set; }
        public List<Evaluacion> Evaluacion { get; set; }
        public List<Venta> Venta { get; set; }
        public Cliente()
        {
            Evaluacion = new List<Evaluacion>();
            Venta = new List<Venta>();
        }
         
        //public static object EvaluacionId { get; set; }
    }
}
