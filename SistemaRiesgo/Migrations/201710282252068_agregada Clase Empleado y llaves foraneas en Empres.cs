namespace SistemaRiesgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregadaClaseEmpleadoyllavesforaneasenEmpres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        codDepartamento = c.Int(),
                        codEmpresa = c.Int(),
                        idUsuario = c.String(),
                        departamento_codigo = c.Int(),
                        empresa_codigo = c.Int(),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.Departamentoes", t => t.departamento_codigo)
                .ForeignKey("dbo.Empresas", t => t.empresa_codigo)
                .Index(t => t.departamento_codigo)
                .Index(t => t.empresa_codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleadoes", "empresa_codigo", "dbo.Empresas");
            DropForeignKey("dbo.Empleadoes", "departamento_codigo", "dbo.Departamentoes");
            DropIndex("dbo.Empleadoes", new[] { "empresa_codigo" });
            DropIndex("dbo.Empleadoes", new[] { "departamento_codigo" });
            DropTable("dbo.Empleadoes");
        }
    }
}
