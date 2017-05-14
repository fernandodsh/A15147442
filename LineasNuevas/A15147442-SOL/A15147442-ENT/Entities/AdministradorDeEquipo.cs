using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class AdministradorDeEquipo
    {
        public int AdmiEquipoId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Area { get; set; }

        public string Cargo { get; set; }

        public EquipoDeCelular EquipoDeCelular { get; set; }

        public int EquipoCelularId { get; set; }
    }
}
