using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using A15147442_ENT.Entities;

namespace A15147442_PER.EntityTypeConfigurations
{
    public class EvaluacionConfiguration : EntityTypeConfiguration<Evaluacion>
    {
        public EvaluacionConfiguration()
        {

            ToTable("Evaluacion");
            HasKey(c => c.EvaluacionId);





            HasRequired(v => v.EquipoDeCelular)
           .WithMany(g => g.Evaluacion)
           .HasForeignKey(v => v.EquipoCelularId);

            HasRequired(v => v.EstadoDeEvaluacion)
           .WithMany(g => g.Evaluacion)
           .HasForeignKey(v => v.EstadoId);

            HasRequired(v => v.TipoDeEvaluacion)
           .WithMany(g => g.Evaluacion)
           .HasForeignKey(v => v.TipoEvaluacionId);

            HasRequired(v => v.Plan)
           .WithMany(g => g.Evaluacion)
           .HasForeignKey(v => v.PlanId);


            HasRequired(v => v.LineaTelefonica)
           .WithMany(g => g.Evaluacion)
           .HasForeignKey(v => v.LineaId);

            HasRequired(v => v.Cliente)
           .WithMany(g => g.Evaluacion)
           .HasForeignKey(v => v.ClienteId);


            HasMany(v => v.CentroDeAtencion)
                .WithMany(t => t.Evaluacion)
                .Map(m =>
                {
                    m.ToTable("Evaluacion_CentroDeAtencion");
                    m.MapLeftKey("EvaluacionId");
                    m.MapRightKey("CentroId");
                });

            HasMany(v => v.Trabajador)
               .WithMany(t => t.Evaluacion)
               .Map(m =>
               {
                   m.ToTable("Evaluacion_Trabajador");
                   m.MapLeftKey("EvaluacionId");
                   m.MapRightKey("TrabajadorId");
               });
        }
    }
}
