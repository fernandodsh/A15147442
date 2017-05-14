using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class Departamento
    {
        public int DepartamentoId  { get; set; }

        public string Departamentos { get; set; }

        public Provincia Provincia { get; set; }

        public int ProvinciaId { get; set; }

        public List<Ubigeo> Ubigeo { get; set; }

        public Departamento()
        {
            Ubigeo = new List<Ubigeo>();
        }
    }
}
