using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class Provincia
    {
        public int ProvinciaId { get; set; }

        public string Nombre { get; set; }

        public Distrito Distrito { get; set;}

        public int DistritoId { get; set; }

        public List<Departamento> Departamento { get; set; }

        public List<Ubigeo> Ubigeo { get; set; }

        public Provincia()
        {
            Departamento = new List<Departamento>();
            Ubigeo = new List<Ubigeo>();
        }

    }
}
