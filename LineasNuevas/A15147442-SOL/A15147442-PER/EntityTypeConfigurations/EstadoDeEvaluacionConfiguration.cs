using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class EstadoDeEvaluacionConfiguration : EntityTypeConfiguration<EstadoDeEvaluacion>
    {
        public EstadoDeEvaluacionConfiguration()
        {
            ToTable("Estado_De_Evaluacion");
            HasKey(c => c.EstadoId);



        }
    }
}
