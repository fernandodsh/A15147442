using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class VentaConfiguration : EntityTypeConfiguration<Venta>
    {
        public VentaConfiguration()
        {
            ToTable("Ventas");
           HasKey(c => c.VentaId);


          HasRequired(v =>v.LineaTelefonica)
       .WithMany(g => g.Venta)
       .HasForeignKey(v => v.LineaId);

          HasRequired(v => v.Contrato)
       .WithMany(g => g.Venta)
       .HasForeignKey(v => v.ContratoId);

          HasRequired(v => v.TipoDePago)
       .WithMany(g => g.Venta)
       .HasForeignKey(v => v.TipoPagoId);

          HasRequired(v => v.Cliente)
       .WithMany(g => g.Venta)
       .HasForeignKey(v => v.ClienteId);

          HasMany(v => v.CentroAtencion)
             .WithMany(t => t.Venta)
             .Map(m =>
             {
                 m.ToTable("Detalle_Ventas_CentroDeAtencion");
                 m.MapLeftKey("VentaId");
                 m.MapRightKey("CentroId");
             });


        }
    }
}
