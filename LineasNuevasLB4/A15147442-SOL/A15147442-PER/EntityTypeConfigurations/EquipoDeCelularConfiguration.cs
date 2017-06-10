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
    public class EquipoDeCelularConfiguration : EntityTypeConfiguration<EquipoDeCelular>
    {
        public EquipoDeCelularConfiguration()
        {
            ToTable("EquipoDeCelular");
            HasKey(c => c.EquipoCelularId);
            Property(c => c.EquipoCelularId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(v => v.Marca)
                .HasMaxLength(255);
        }
    }
}
