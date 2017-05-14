using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class Distrito
    {
        public int DistritoId { get; set; }

        public string Distritos{ get; set; }

        public List<Provincia> Provincia { get; set; }

        public List<Ubigeo> Ubigeo { get; set; }

        public Distrito()
        {
            Provincia = new List<Provincia>();
            Ubigeo = new List<Ubigeo>();
        }
    }
}
