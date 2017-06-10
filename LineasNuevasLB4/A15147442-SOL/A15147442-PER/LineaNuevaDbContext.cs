using System;
using System.Collections.Generic;
using System.Data.Entity;
using A15147442_ENT.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A15147442_PER.EntityTypeConfigurations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A15147442_PER
{
    public class LineaNuevaDbContext : DbContext
    {

        public DbSet<CentroDeAtencion> CentroDeAtencion { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<EquipoDeCelular> EquipoDeCelular { get; set; }
   
        public DbSet<Evaluacion> Evaluacion { get; set; }
        public DbSet<LineaTelefonica> LineaTelefonica { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Provincia> Provincia { get; set; }

        public DbSet<Trabajador> Trabajador { get; set;}
 
        public DbSet<Venta> Venta { get; set; }

        public LineaNuevaDbContext() : base("LineasNuevas")
		{

		}


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Configurations.Add(new CentroDeAtencionConfiguration());
            //modelBuilder.Configurations.Add(new ClienteConfiguration());
            //modelBuilder.Configurations.Add(new ContratoConfiguration());
            //modelBuilder.Configurations.Add(new DepartamentoConfiguration());
            //modelBuilder.Configurations.Add(new DireccionConfiguration());
            //modelBuilder.Configurations.Add(new DistritoConfiguration());
            //modelBuilder.Configurations.Add(new EquipoDeCelularConfiguration());

            //modelBuilder.Configurations.Add(new EvaluacionConfiguration());
            //modelBuilder.Configurations.Add(new LineaTelefonicaConfiguration());
            //modelBuilder.Configurations.Add(new PlanConfiguration());
            //modelBuilder.Configurations.Add(new ProvinciaConfiguration());
 
            //modelBuilder.Configurations.Add(new TrabajadorConfiguration());
            //modelBuilder.Configurations.Add(new VentaConfiguration());

            modelBuilder.Entity<CentroDeAtencion>().ToTable("Centro_De_Atencion");
            modelBuilder.Entity<CentroDeAtencion>().HasKey(c => c.CentroId);
            modelBuilder.Entity<CentroDeAtencion>().Property(c => c.CentroId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<CentroDeAtencion>().Property(v => v.Centro)
                .HasMaxLength(255);
            modelBuilder.Entity<CentroDeAtencion>().HasRequired(v => v.Direccion).WithRequiredPrincipal(c => c.CentroDeAtencion);


            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<Cliente>().HasKey(c => c.ClienteId);
            modelBuilder.Entity<Cliente>().Property(c => c.ClienteId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Cliente>().Property(v => v.Nombre)
                .HasMaxLength(255);
            

            modelBuilder.Entity<Contrato>().ToTable("Contrato");
            modelBuilder.Entity<Contrato>().HasKey(c => c.ContratoId);
            modelBuilder.Entity<Contrato>().Property(c => c.ContratoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Contrato>().Property(v => v.NombreDeLaEmpresa)
                .HasMaxLength(255);

            modelBuilder.Entity<Departamento>().ToTable("Departamento");
            modelBuilder.Entity<Departamento>().HasKey(c => c.DepartamentoId);
            modelBuilder.Entity<Departamento>().Property(c => c.DepartamentoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Departamento>().Property(v => v.Descripcion)
                .HasMaxLength(255);
            

            modelBuilder.Entity<Direccion>().ToTable("Direccion");
            modelBuilder.Entity<Direccion>().HasKey(c => c.DireccionId);
            modelBuilder.Entity<Direccion>().Property(c => c.DireccionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Direccion>().Property(v => v.Descripcion)
                .HasMaxLength(255);
          


            modelBuilder.Entity<Distrito>().ToTable("Distrito");
            modelBuilder.Entity<Distrito>().HasKey(c => c.DistritoId);
            modelBuilder.Entity<Distrito>().Property(c => c.DistritoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Distrito>().Property(v => v.Descripcion)
                .HasMaxLength(255);

            modelBuilder.Entity<EquipoDeCelular>().ToTable("EquipoDeCelular");
            modelBuilder.Entity<EquipoDeCelular>().HasKey(c => c.EquipoCelularId);
            modelBuilder.Entity<EquipoDeCelular>().Property(c => c.EquipoCelularId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<EquipoDeCelular>().Property(v => v.Marca)
                .HasMaxLength(255);
            modelBuilder.Entity<EquipoDeCelular>().HasMany(e => e.Evaluacion).WithRequired(d => d.EquipoDeCelular).HasForeignKey(d => d.EquipoCelularId);

            modelBuilder.Entity<Evaluacion>().ToTable("Evaluacion");
            modelBuilder.Entity<Evaluacion>().HasKey(c => c.EvaluacionId);
            modelBuilder.Entity<Evaluacion>().Property(c => c.EvaluacionId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Evaluacion>().Property(v => v.Descricpion)
                .HasMaxLength(255);
            modelBuilder.Entity<Evaluacion>().HasRequired(c => c.Cliente).WithMany(e => e.Evaluacion).HasForeignKey(c => c.ClienteId);
            modelBuilder.Entity<Evaluacion>().HasRequired(d => d.Plan).WithMany(e => e.Evaluacion).HasForeignKey(d => d.PlanId);
            modelBuilder.Entity<Evaluacion>().HasRequired(d => d.LineaTelefonica).WithMany(e => e.Evaluacion).HasForeignKey(d => d.LineaId);

            modelBuilder.Entity<LineaTelefonica>().ToTable("Linea_Telefonica");
            modelBuilder.Entity<LineaTelefonica>().HasKey(c => c.LineaId);
            modelBuilder.Entity<LineaTelefonica>().Property(c => c.LineaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<LineaTelefonica>().Property(v => v.Descripcion)
                .HasMaxLength(255);


            modelBuilder.Entity<Plan>().ToTable("Plan");
            modelBuilder.Entity<Plan>().HasKey(c => c.PlanId);
            modelBuilder.Entity<Plan>().Property(c => c.PlanId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Plan>().Property(v => v.Descripcion)
                .HasMaxLength(255);


            modelBuilder.Entity<Provincia>().ToTable("Provincia");
            modelBuilder.Entity<Provincia>().HasKey(c => c.ProvinciaId);
            modelBuilder.Entity<Provincia>().Property(c => c.ProvinciaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Provincia>().Property(v => v.Descripcion)
                .HasMaxLength(255);

            modelBuilder.Entity<Trabajador>().ToTable("Trabajador");
            modelBuilder.Entity<Trabajador>().HasKey(c => c.TrabajadorId);
            modelBuilder.Entity<Trabajador>().Property(c => c.TrabajadorId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Trabajador>().Property(v => v.Nombre)
                .HasMaxLength(255);

            modelBuilder.Entity<Venta>().ToTable("Ventas");
            modelBuilder.Entity<Venta>().HasKey(c => c.VentaId);
            modelBuilder.Entity<Venta>().Property(c => c.VentaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Venta>().Property(v => v.Encargado)
                .HasMaxLength(255);
            modelBuilder.Entity<Venta>().HasRequired(c => c.Cliente).WithMany(v => v.Venta).HasForeignKey(c => c.ClienteId);








            base.OnModelCreating(modelBuilder);
        }
    } 
}
