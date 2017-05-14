using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class CentroDeAtencionConfiguration : EntityTypeConfiguration<CentroDeAtencion>
    {
        public CentroDeAtencionConfiguration()
        {
            ToTable("Centro_De_Atencion");
            HasKey(c => c.CentroId);


            HasRequired(v => v.Direccion)
              .WithMany(g => g.CentroDeAtencion)
              .HasForeignKey(v => v.DireccionId);

        }
    }
}
