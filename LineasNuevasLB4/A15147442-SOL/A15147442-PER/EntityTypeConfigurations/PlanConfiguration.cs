using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class PlanConfiguration : EntityTypeConfiguration<Plan>
    {
        public PlanConfiguration()
        {
            ToTable("Plan");
            HasKey(c => c.PlanId);
            Property(c => c.PlanId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(v => v.Descripcion)
                .HasMaxLength(255);

        }
    }
}
