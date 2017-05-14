using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class TipoTrabajador
    {
        public int TipoTrabajadorId { get; set; }

        public string Nombre { get; set;}

        public List<Trabajador> _Trabajador { get; set; }

        public TipoTrabajador()
        {
            _Trabajador = new List<Trabajador>();
        }
        
        
        
   }
}
