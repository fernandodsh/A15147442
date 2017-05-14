using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class EquipoDeCelular
    {
        public int EquipoCelularId { get; set; }

        public string Nombre { get; set; }

        public string Marca { get; set; }

        public List<AdministradorDeEquipo> AdministradorDeEquipo { get; set; }

        public List<Evaluacion> Evaluacion { get; set; }

        public EquipoDeCelular()
        {
            AdministradorDeEquipo = new List<AdministradorDeEquipo>();
            Evaluacion = new List<Evaluacion>();
        }



    }
}
