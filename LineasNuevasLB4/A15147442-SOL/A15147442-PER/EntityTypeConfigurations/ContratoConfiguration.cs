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
    public class ContratoConfiguration : EntityTypeConfiguration<Contrato>
    {
        public ContratoConfiguration()
        {
            ToTable("Contrato");
            HasKey(c => c.ContratoId);
            Property(c => c.ContratoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(v => v.NombreDeLaEmpresa)
                .HasMaxLength(255);

        }
    }
}
