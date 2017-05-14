namespace A15147442_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrador_De_Equipo",
                c => new
                    {
                        AdmiEquipoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Area = c.String(),
                        Cargo = c.String(),
                        EquipoCelularId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdmiEquipoId)
                .ForeignKey("dbo.EquipoDeCelular", t => t.EquipoCelularId, cascadeDelete: true)
                .Index(t => t.EquipoCelularId);
            
            CreateTable(
                "dbo.EquipoDeCelular",
                c => new
                    {
                        EquipoCelularId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Marca = c.String(),
                    })
                .PrimaryKey(t => t.EquipoCelularId);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        EvaluacionId = c.Int(nullable: false, identity: true),
                        Descricpion = c.String(),
                        EquipoCelularId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        TipoEvaluacionId = c.Int(nullable: false),
                        PlanId = c.Int(nullable: false),
                        LineaId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluacionId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.EquipoDeCelular", t => t.EquipoCelularId, cascadeDelete: true)
                .ForeignKey("dbo.Estado_De_Evaluacion", t => t.EstadoId, cascadeDelete: true)
                .ForeignKey("dbo.Linea_Telefonica", t => t.LineaId, cascadeDelete: true)
                .ForeignKey("dbo.Plan", t => t.PlanId, cascadeDelete: true)
                .ForeignKey("dbo.TipoDeEvaluacion", t => t.TipoEvaluacionId, cascadeDelete: true)
                .Index(t => t.EquipoCelularId)
                .Index(t => t.EstadoId)
                .Index(t => t.TipoEvaluacionId)
                .Index(t => t.PlanId)
                .Index(t => t.LineaId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Centro_De_Atencion",
                c => new
                    {
                        CentroId = c.Int(nullable: false, identity: true),
                        NombreDelCentro = c.String(),
                        DireccionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CentroId)
                .ForeignKey("dbo.Direccion", t => t.DireccionId, cascadeDelete: true)
                .Index(t => t.DireccionId);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        DireccionId = c.Int(nullable: false, identity: true),
                        Direcciones = c.String(),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DireccionId)
                .ForeignKey("dbo.Ubigeo", t => t.UbigeoId, cascadeDelete: true)
                .Index(t => t.UbigeoId);
            
            CreateTable(
                "dbo.Ubigeo",
                c => new
                    {
                        UbigeoId = c.Int(nullable: false, identity: true),
                        CodigoGeografico = c.String(),
                        Distrito_DistritoId = c.Int(),
                        Provincia_ProvinciaId = c.Int(),
                        Departamento_DepartamentoId = c.Int(),
                    })
                .PrimaryKey(t => t.UbigeoId)
                .ForeignKey("dbo.Distrito", t => t.Distrito_DistritoId)
                .ForeignKey("dbo.Provincia", t => t.Provincia_ProvinciaId)
                .ForeignKey("dbo.Departamento", t => t.Departamento_DepartamentoId)
                .Index(t => t.Distrito_DistritoId)
                .Index(t => t.Provincia_ProvinciaId)
                .Index(t => t.Departamento_DepartamentoId);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        Encargado = c.String(),
                        FechaVendida = c.DateTime(nullable: false),
                        ContratoId = c.Int(nullable: false),
                        TipoPagoId = c.Int(nullable: false),
                        LineaId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Contrato", t => t.ContratoId, cascadeDelete: true)
                .ForeignKey("dbo.Linea_Telefonica", t => t.LineaId, cascadeDelete: true)
                .ForeignKey("dbo.Tipo_De_Pago", t => t.TipoPagoId, cascadeDelete: true)
                .Index(t => t.ContratoId)
                .Index(t => t.TipoPagoId)
                .Index(t => t.LineaId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        DNI = c.Int(nullable: false),
                        Correo = c.String(),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Contrato",
                c => new
                    {
                        ContratoId = c.Int(nullable: false, identity: true),
                        Contratos = c.String(),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContratoId);
            
            CreateTable(
                "dbo.Linea_Telefonica",
                c => new
                    {
                        LineaId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        TipoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LineaId)
                .ForeignKey("dbo.Tipo_De_Linea", t => t.TipoId, cascadeDelete: true)
                .Index(t => t.TipoId);
            
            CreateTable(
                "dbo.Administrador_De_Linea",
                c => new
                    {
                        AdmiLineaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Area = c.String(),
                        LineaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdmiLineaId)
                .ForeignKey("dbo.Linea_Telefonica", t => t.LineaId, cascadeDelete: true)
                .Index(t => t.LineaId);
            
            CreateTable(
                "dbo.Tipo_De_Linea",
                c => new
                    {
                        TipoId = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.TipoId);
            
            CreateTable(
                "dbo.Tipo_De_Pago",
                c => new
                    {
                        TipoPagoId = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Monto = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TipoPagoId);
            
            CreateTable(
                "dbo.Estado_De_Evaluacion",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        TipoPlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId)
                .ForeignKey("dbo.Tipo_De_Plan", t => t.TipoPlanId, cascadeDelete: true)
                .Index(t => t.TipoPlanId);
            
            CreateTable(
                "dbo.Tipo_De_Plan",
                c => new
                    {
                        TipoPlanId = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.TipoPlanId);
            
            CreateTable(
                "dbo.TipoDeEvaluacion",
                c => new
                    {
                        TipoEvaluacionId = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.TipoEvaluacionId);
            
            CreateTable(
                "dbo.Trabajador",
                c => new
                    {
                        TrabajadorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        DNI = c.Int(nullable: false),
                        FechaInicioContrato = c.DateTime(nullable: false),
                        TipoTrabajadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrabajadorId)
                .ForeignKey("dbo.Tipo_Trabajador", t => t.TipoTrabajadorId, cascadeDelete: true)
                .Index(t => t.TipoTrabajadorId);
            
            CreateTable(
                "dbo.Tipo_Trabajador",
                c => new
                    {
                        TipoTrabajadorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.TipoTrabajadorId);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false, identity: true),
                        Departamentos = c.String(),
                        ProvinciaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartamentoId)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaId, cascadeDelete: true)
                .Index(t => t.ProvinciaId);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        ProvinciaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        DistritoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinciaId)
                .ForeignKey("dbo.Distrito", t => t.DistritoId, cascadeDelete: true)
                .Index(t => t.DistritoId);
            
            CreateTable(
                "dbo.Distrito",
                c => new
                    {
                        DistritoId = c.Int(nullable: false, identity: true),
                        Distritos = c.String(),
                    })
                .PrimaryKey(t => t.DistritoId);
            
            CreateTable(
                "dbo.Detalle_Ventas_CentroDeAtencion",
                c => new
                    {
                        VentaId = c.Int(nullable: false),
                        CentroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.VentaId, t.CentroId })
                .ForeignKey("dbo.Ventas", t => t.VentaId, cascadeDelete: true)
                .ForeignKey("dbo.Centro_De_Atencion", t => t.CentroId, cascadeDelete: true)
                .Index(t => t.VentaId)
                .Index(t => t.CentroId);
            
            CreateTable(
                "dbo.Evaluacion_CentroDeAtencion",
                c => new
                    {
                        EvaluacionId = c.Int(nullable: false),
                        CentroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EvaluacionId, t.CentroId })
                .ForeignKey("dbo.Evaluacion", t => t.EvaluacionId, cascadeDelete: true)
                .ForeignKey("dbo.Centro_De_Atencion", t => t.CentroId, cascadeDelete: true)
                .Index(t => t.EvaluacionId)
                .Index(t => t.CentroId);
            
            CreateTable(
                "dbo.Evaluacion_Trabajador",
                c => new
                    {
                        EvaluacionId = c.Int(nullable: false),
                        TrabajadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EvaluacionId, t.TrabajadorId })
                .ForeignKey("dbo.Evaluacion", t => t.EvaluacionId, cascadeDelete: true)
                .ForeignKey("dbo.Trabajador", t => t.TrabajadorId, cascadeDelete: true)
                .Index(t => t.EvaluacionId)
                .Index(t => t.TrabajadorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ubigeo", "Departamento_DepartamentoId", "dbo.Departamento");
            DropForeignKey("dbo.Departamento", "ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Ubigeo", "Provincia_ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Provincia", "DistritoId", "dbo.Distrito");
            DropForeignKey("dbo.Ubigeo", "Distrito_DistritoId", "dbo.Distrito");
            DropForeignKey("dbo.Administrador_De_Equipo", "EquipoCelularId", "dbo.EquipoDeCelular");
            DropForeignKey("dbo.Evaluacion_Trabajador", "TrabajadorId", "dbo.Trabajador");
            DropForeignKey("dbo.Evaluacion_Trabajador", "EvaluacionId", "dbo.Evaluacion");
            DropForeignKey("dbo.Trabajador", "TipoTrabajadorId", "dbo.Tipo_Trabajador");
            DropForeignKey("dbo.Evaluacion", "TipoEvaluacionId", "dbo.TipoDeEvaluacion");
            DropForeignKey("dbo.Evaluacion", "PlanId", "dbo.Plan");
            DropForeignKey("dbo.Plan", "TipoPlanId", "dbo.Tipo_De_Plan");
            DropForeignKey("dbo.Evaluacion", "LineaId", "dbo.Linea_Telefonica");
            DropForeignKey("dbo.Evaluacion", "EstadoId", "dbo.Estado_De_Evaluacion");
            DropForeignKey("dbo.Evaluacion", "EquipoCelularId", "dbo.EquipoDeCelular");
            DropForeignKey("dbo.Evaluacion", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Evaluacion_CentroDeAtencion", "CentroId", "dbo.Centro_De_Atencion");
            DropForeignKey("dbo.Evaluacion_CentroDeAtencion", "EvaluacionId", "dbo.Evaluacion");
            DropForeignKey("dbo.Ventas", "TipoPagoId", "dbo.Tipo_De_Pago");
            DropForeignKey("dbo.Ventas", "LineaId", "dbo.Linea_Telefonica");
            DropForeignKey("dbo.Linea_Telefonica", "TipoId", "dbo.Tipo_De_Linea");
            DropForeignKey("dbo.Administrador_De_Linea", "LineaId", "dbo.Linea_Telefonica");
            DropForeignKey("dbo.Ventas", "ContratoId", "dbo.Contrato");
            DropForeignKey("dbo.Ventas", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Detalle_Ventas_CentroDeAtencion", "CentroId", "dbo.Centro_De_Atencion");
            DropForeignKey("dbo.Detalle_Ventas_CentroDeAtencion", "VentaId", "dbo.Ventas");
            DropForeignKey("dbo.Centro_De_Atencion", "DireccionId", "dbo.Direccion");
            DropForeignKey("dbo.Direccion", "UbigeoId", "dbo.Ubigeo");
            DropIndex("dbo.Evaluacion_Trabajador", new[] { "TrabajadorId" });
            DropIndex("dbo.Evaluacion_Trabajador", new[] { "EvaluacionId" });
            DropIndex("dbo.Evaluacion_CentroDeAtencion", new[] { "CentroId" });
            DropIndex("dbo.Evaluacion_CentroDeAtencion", new[] { "EvaluacionId" });
            DropIndex("dbo.Detalle_Ventas_CentroDeAtencion", new[] { "CentroId" });
            DropIndex("dbo.Detalle_Ventas_CentroDeAtencion", new[] { "VentaId" });
            DropIndex("dbo.Provincia", new[] { "DistritoId" });
            DropIndex("dbo.Departamento", new[] { "ProvinciaId" });
            DropIndex("dbo.Trabajador", new[] { "TipoTrabajadorId" });
            DropIndex("dbo.Plan", new[] { "TipoPlanId" });
            DropIndex("dbo.Administrador_De_Linea", new[] { "LineaId" });
            DropIndex("dbo.Linea_Telefonica", new[] { "TipoId" });
            DropIndex("dbo.Ventas", new[] { "ClienteId" });
            DropIndex("dbo.Ventas", new[] { "LineaId" });
            DropIndex("dbo.Ventas", new[] { "TipoPagoId" });
            DropIndex("dbo.Ventas", new[] { "ContratoId" });
            DropIndex("dbo.Ubigeo", new[] { "Departamento_DepartamentoId" });
            DropIndex("dbo.Ubigeo", new[] { "Provincia_ProvinciaId" });
            DropIndex("dbo.Ubigeo", new[] { "Distrito_DistritoId" });
            DropIndex("dbo.Direccion", new[] { "UbigeoId" });
            DropIndex("dbo.Centro_De_Atencion", new[] { "DireccionId" });
            DropIndex("dbo.Evaluacion", new[] { "ClienteId" });
            DropIndex("dbo.Evaluacion", new[] { "LineaId" });
            DropIndex("dbo.Evaluacion", new[] { "PlanId" });
            DropIndex("dbo.Evaluacion", new[] { "TipoEvaluacionId" });
            DropIndex("dbo.Evaluacion", new[] { "EstadoId" });
            DropIndex("dbo.Evaluacion", new[] { "EquipoCelularId" });
            DropIndex("dbo.Administrador_De_Equipo", new[] { "EquipoCelularId" });
            DropTable("dbo.Evaluacion_Trabajador");
            DropTable("dbo.Evaluacion_CentroDeAtencion");
            DropTable("dbo.Detalle_Ventas_CentroDeAtencion");
            DropTable("dbo.Distrito");
            DropTable("dbo.Provincia");
            DropTable("dbo.Departamento");
            DropTable("dbo.Tipo_Trabajador");
            DropTable("dbo.Trabajador");
            DropTable("dbo.TipoDeEvaluacion");
            DropTable("dbo.Tipo_De_Plan");
            DropTable("dbo.Plan");
            DropTable("dbo.Estado_De_Evaluacion");
            DropTable("dbo.Tipo_De_Pago");
            DropTable("dbo.Tipo_De_Linea");
            DropTable("dbo.Administrador_De_Linea");
            DropTable("dbo.Linea_Telefonica");
            DropTable("dbo.Contrato");
            DropTable("dbo.Cliente");
            DropTable("dbo.Ventas");
            DropTable("dbo.Ubigeo");
            DropTable("dbo.Direccion");
            DropTable("dbo.Centro_De_Atencion");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.EquipoDeCelular");
            DropTable("dbo.Administrador_De_Equipo");
        }
    }
}
