using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class DepartamentoConfiguration : EntityTypeConfiguration<Departamento>
    {
        public DepartamentoConfiguration()
        {
            ToTable("Departamento");
            HasKey(c => c.DepartamentoId);


            HasRequired(v => v.Provincia)
               .WithMany(g => g.Departamento)
               .HasForeignKey(v => v.ProvinciaId);


        }
    }
}
