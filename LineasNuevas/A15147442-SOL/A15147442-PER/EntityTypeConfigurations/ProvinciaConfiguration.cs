using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class ProvinciaConfiguration : EntityTypeConfiguration<Provincia>
    {
        public ProvinciaConfiguration()
        {
            ToTable("Provincia");
            HasKey(c => c.ProvinciaId);


            HasRequired(v => v.Distrito)
          .WithMany(g => g.Provincia)
          .HasForeignKey(v => v.DistritoId);
        }
    }
}
