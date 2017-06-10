using A15147442_ENT.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace A15147442_ENT.Entities
{
    public class Evaluacion
    {
        public int EvaluacionId { get; set; }

        public string Descricpion { get; set; }

        public EquipoDeCelular EquipoDeCelular { get; set; }

        public int EquipoCelularId { get; set; }

        public EstadoDeEvaluacion EstadoDeEvaluacion { get; set; }

        public TipoDeEvaluacion TipoDeEvaluacion { get; set; }

        public Plan Plan { get; set; }

        public int PlanId { get; set; }

        public LineaTelefonica LineaTelefonica { get; set; }

        public int LineaId { get; set; }

        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }


    }
}
