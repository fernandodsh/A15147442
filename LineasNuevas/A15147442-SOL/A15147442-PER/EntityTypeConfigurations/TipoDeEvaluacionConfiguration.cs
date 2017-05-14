using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class TipoDeEvaluacionConfiguration : EntityTypeConfiguration<TipoDeEvaluacion>
    {
        public TipoDeEvaluacionConfiguration()
        {
            ToTable("TipoDeEvaluacion");
            HasKey(c => c.TipoEvaluacionId);

        }
    }
}
