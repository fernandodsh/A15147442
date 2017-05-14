using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class PlanConfiguration : EntityTypeConfiguration<Plan>
    {
        public PlanConfiguration()
        {
            ToTable("Plan");
            HasKey(c => c.PlanId);

            HasRequired(v => v.TipoPlan)
              .WithMany(g => g.Plan)
              .HasForeignKey(v => v.TipoPlanId);
        }
    }
}
