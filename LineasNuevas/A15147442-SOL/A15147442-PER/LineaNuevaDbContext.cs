using System;
using System.Collections.Generic;
using System.Data.Entity;
using A15147442_ENT.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A15147442_PER.EntityTypeConfigurations;

namespace A15147442_PER
{
    public class LineaNuevaDbContext : DbContext
    {
        public DbSet<AdministradorDeEquipo> AdministradoDeEquipo { get; set; }
        public DbSet<AdministradorDeLinea> AdministradorDeLinea { get; set; }
        public DbSet<CentroDeAtencion> CentroDeAtencion { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<EquipoDeCelular> EquipoDeCelular { get; set; }
        public DbSet<EstadoDeEvaluacion> EstadoDeEvaluacion { get; set; }
        public DbSet<Evaluacion> Evaluacion { get; set; }
        public DbSet<LineaTelefonica> LineaTelefonica { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<TipoDeEvaluacion> TipoDeEvaluacion { get; set; }
        public DbSet<TipoDeLinea> TipoDeLinea { get; set;}
        public DbSet<TipoDePago> TipoDePago { get; set; }
        public DbSet<TipoPlan> TipoPlan { get; set;}
        public DbSet<TipoTrabajador> TipoTrabajador { get; set; }
        public DbSet<Trabajador> Trabajador { get; set;}
        public DbSet<Ubigeo> Ubigeo { get; set; }
        public DbSet<Venta> Venta { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdministradorDeEquipoConfiguration());
            modelBuilder.Configurations.Add(new AdministradorDeLineaConfiguration());
            modelBuilder.Configurations.Add(new CentroDeAtencionConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ContratoConfiguration());
            modelBuilder.Configurations.Add(new DepartamentoConfiguration());
            modelBuilder.Configurations.Add(new DireccionConfiguration());
            modelBuilder.Configurations.Add(new DistritoConfiguration());
            modelBuilder.Configurations.Add(new EquipoDeCelularConfiguration());
            modelBuilder.Configurations.Add(new EstadoDeEvaluacionConfiguration());
            modelBuilder.Configurations.Add(new EvaluacionConfiguration());
            modelBuilder.Configurations.Add(new LineaTelefonicaConfiguration());
            modelBuilder.Configurations.Add(new PlanConfiguration());
            modelBuilder.Configurations.Add(new ProvinciaConfiguration());
            modelBuilder.Configurations.Add(new TipoDeEvaluacionConfiguration());
            modelBuilder.Configurations.Add(new TipoDeLineaConfiguration());
            modelBuilder.Configurations.Add(new TipoDePagoConfiguration());
            modelBuilder.Configurations.Add(new TipoPlanConfiguration());
            modelBuilder.Configurations.Add(new TipoTrabajadorConfiguration());
            modelBuilder.Configurations.Add(new TrabajadorConfiguration());
            modelBuilder.Configurations.Add(new UbigeoConfiguration());
            modelBuilder.Configurations.Add(new VentaConfiguration());


 

            base.OnModelCreating(modelBuilder);
        }
    } 
}
