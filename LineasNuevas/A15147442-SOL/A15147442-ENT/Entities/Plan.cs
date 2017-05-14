﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class Plan
    {
        public int PlanId { get; set; }

        public string Descripcion { get; set; }

        public TipoPlan TipoPlan { get; set;}

        public int TipoPlanId { get; set; }

        public List<Evaluacion> Evaluacion { get; set; }

        public Plan()
        {
            Evaluacion = new List<Evaluacion>();
        }


    }
}
