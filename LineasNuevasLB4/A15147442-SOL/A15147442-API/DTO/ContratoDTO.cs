using A15147442_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A15147442_API.DTO
{
    public class ContratoDTO
    {
        public int ContratoId { get; set; }

        public string NombreDeLaEmpresa { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFin { get; set; }
    }
}