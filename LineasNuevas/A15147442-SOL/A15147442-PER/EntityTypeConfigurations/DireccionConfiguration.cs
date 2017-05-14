using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class DireccionConfiguration : EntityTypeConfiguration<Direccion>
    {
        public DireccionConfiguration()
        {
            ToTable("Direccion");
            HasKey(c => c.DireccionId);



            HasRequired(v => v.Ubigeo)
               .WithMany(g => g.Direccion)
               .HasForeignKey(v => v.UbigeoId);
        }
    }
}
