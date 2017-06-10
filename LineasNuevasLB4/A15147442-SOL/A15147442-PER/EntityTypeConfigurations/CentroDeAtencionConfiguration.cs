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
    public class CentroDeAtencionConfiguration : EntityTypeConfiguration<CentroDeAtencion>
    {
        public CentroDeAtencionConfiguration()
        {
            ToTable("Centro_De_Atencion");
            HasKey(c => c.CentroId);
            Property(c => c.CentroId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(v => v.Centro)
                .HasMaxLength(255);

            HasRequired(v => v.Direccion)
              .WithRequiredPrincipal(c=>c.CentroDeAtencion);

        }
    }
}
