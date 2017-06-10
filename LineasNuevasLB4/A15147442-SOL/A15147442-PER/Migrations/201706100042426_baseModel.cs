namespace A15147442_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class baseModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Centro_De_Atencion",
                c => new
                    {
                        CentroId = c.Int(nullable: false, identity: true),
                        Centro = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.CentroId);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        DireccionId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.DireccionId)
                .ForeignKey("dbo.Centro_De_Atencion", t => t.DireccionId)
                .Index(t => t.DireccionId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 255),
                        Apellido = c.String(),
                        DNI = c.Int(nullable: false),
                        Correo = c.String(),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        EvaluacionId = c.Int(nullable: false, identity: true),
                        Descricpion = c.String(maxLength: 255),
                        EquipoCelularId = c.Int(nullable: false),
                        EstadoDeEvaluacion = c.Byte(nullable: false),
                        TipoDeEvaluacion = c.Byte(nullable: false),
                        PlanId = c.Int(nullable: false),
                        LineaId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluacionId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.EquipoDeCelular", t => t.EquipoCelularId, cascadeDelete: true)
                .ForeignKey("dbo.Linea_Telefonica", t => t.LineaId, cascadeDelete: true)
                .ForeignKey("dbo.Plan", t => t.PlanId, cascadeDelete: true)
                .Index(t => t.EquipoCelularId)
                .Index(t => t.PlanId)
                .Index(t => t.LineaId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.EquipoDeCelular",
                c => new
                    {
                        EquipoCelularId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Marca = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.EquipoCelularId);
            
            CreateTable(
                "dbo.Linea_Telefonica",
                c => new
                    {
                        LineaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 255),
                        TipoDeLinea = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.LineaId);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 255),
                        TipoDePlan = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        Encargado = c.String(maxLength: 255),
                        FechaVendida = c.DateTime(nullable: false),
                        TipoDePago = c.Byte(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Contrato",
                c => new
                    {
                        ContratoId = c.Int(nullable: false, identity: true),
                        NombreDeLaEmpresa = c.String(maxLength: 255),
                        FechaInicial = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContratoId);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Distrito",
                c => new
                    {
                        DistritoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.DistritoId);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        ProvinciaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ProvinciaId);
            
            CreateTable(
                "dbo.Trabajador",
                c => new
                    {
                        TrabajadorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 255),
                        Apellido = c.String(),
                        DNI = c.Int(nullable: false),
                        FechaInicioContrato = c.DateTime(nullable: false),
                        TipoTrabajador = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.TrabajadorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Evaluacion", "PlanId", "dbo.Plan");
            DropForeignKey("dbo.Evaluacion", "LineaId", "dbo.Linea_Telefonica");
            DropForeignKey("dbo.Evaluacion", "EquipoCelularId", "dbo.EquipoDeCelular");
            DropForeignKey("dbo.Evaluacion", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Direccion", "DireccionId", "dbo.Centro_De_Atencion");
            DropIndex("dbo.Ventas", new[] { "ClienteId" });
            DropIndex("dbo.Evaluacion", new[] { "ClienteId" });
            DropIndex("dbo.Evaluacion", new[] { "LineaId" });
            DropIndex("dbo.Evaluacion", new[] { "PlanId" });
            DropIndex("dbo.Evaluacion", new[] { "EquipoCelularId" });
            DropIndex("dbo.Direccion", new[] { "DireccionId" });
            DropTable("dbo.Trabajador");
            DropTable("dbo.Provincia");
            DropTable("dbo.Distrito");
            DropTable("dbo.Departamento");
            DropTable("dbo.Contrato");
            DropTable("dbo.Ventas");
            DropTable("dbo.Plan");
            DropTable("dbo.Linea_Telefonica");
            DropTable("dbo.EquipoDeCelular");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.Cliente");
            DropTable("dbo.Direccion");
            DropTable("dbo.Centro_De_Atencion");
        }
    }
}
