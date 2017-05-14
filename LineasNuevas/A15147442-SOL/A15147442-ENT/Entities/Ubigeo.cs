using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class Ubigeo
    {
        public int UbigeoId { get; set; }

        public string CodigoGeografico { get; set; }

       

        public List<Direccion> Direccion { get; set; }

        public Ubigeo()
        {
            Direccion = new List<Direccion>();
        }



    }
}
