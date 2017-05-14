using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class TrabajadorConfiguration :EntityTypeConfiguration<Trabajador>
    {
        public TrabajadorConfiguration()
        {
            ToTable("Trabajador");
            HasKey(c => c.TrabajadorId);

            HasRequired(v => v.TipoTrabajador)
           .WithMany(g => g._Trabajador)
           .HasForeignKey(v => v.TipoTrabajadorId);
        }
    }
}
