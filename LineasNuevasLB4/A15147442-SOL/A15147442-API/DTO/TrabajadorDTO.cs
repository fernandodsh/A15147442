using A15147442_ENT.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A15147442_API.DTO
{
    public class TrabajadorDTO
    {
        public int TrabajadorId { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int DNI { get; set; }

        public DateTime FechaInicioContrato { get; set; }

        public TipoTrabajador TipoTrabajador { get; set; }
    }
}