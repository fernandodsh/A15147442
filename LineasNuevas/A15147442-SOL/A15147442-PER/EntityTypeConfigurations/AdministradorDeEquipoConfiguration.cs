using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class AdministradorDeEquipoConfiguration : EntityTypeConfiguration<AdministradorDeEquipo>
    {
        public AdministradorDeEquipoConfiguration()
        {
            ToTable("Administrador_De_Equipo");
            HasKey(c => c.AdmiEquipoId);


            HasRequired(v => v.EquipoDeCelular)
              .WithMany(g => g.AdministradorDeEquipo)
              .HasForeignKey(v => v.EquipoCelularId);
        }
    }
}
