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
    public class DistritoConfiguration : EntityTypeConfiguration<Distrito>
    {
        public DistritoConfiguration()
        {
            ToTable("Distrito");
            HasKey(c => c.DistritoId);
            Property(c => c.DistritoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(v => v.Descripcion)
                .HasMaxLength(255);

        }
    }
}
