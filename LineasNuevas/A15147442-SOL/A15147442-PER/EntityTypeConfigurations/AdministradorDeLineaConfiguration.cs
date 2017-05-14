using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class AdministradorDeLineaConfiguration : EntityTypeConfiguration<AdministradorDeLinea>
    {
       public AdministradorDeLineaConfiguration()
       {
           ToTable("Administrador_De_Linea");
           HasKey(c=>c.AdmiLineaId);



           HasRequired(v => v.LineaTelefonica)
              .WithMany(g => g.AdministradorDeLinea)
              .HasForeignKey(v => v.LineaId);
       }
    }
}
