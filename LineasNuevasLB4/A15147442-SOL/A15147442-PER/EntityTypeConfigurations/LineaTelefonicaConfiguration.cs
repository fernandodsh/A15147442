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
    public class LineaTelefonicaConfiguration : EntityTypeConfiguration<LineaTelefonica>
    {
        public LineaTelefonicaConfiguration()
        {
            ToTable("Linea_Telefonica");
            HasKey(c => c.LineaId);
            Property(c => c.LineaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(v => v.Descripcion)
                .HasMaxLength(255);



        }
    }
}
