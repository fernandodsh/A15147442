using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.Entities
{
    public class TipoPlan
    {
        public int TipoPlanId { get; set; }

        public string Tipo { get; set; }

        public List<Plan> Plan { get; set; }

        public TipoPlan()
        {
            Plan = new List<Plan>();
        }
    }
}
