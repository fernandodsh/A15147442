using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class TipoDePagoConfiguration : EntityTypeConfiguration<TipoDePago>
    {
        public TipoDePagoConfiguration()
        {
            ToTable("Tipo_De_Pago");
            HasKey(c => c.TipoPagoId);


        }
    }
}
