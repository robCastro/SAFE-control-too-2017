namespace SistemaRiesgo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradors",
                c => new
                    {
                        usuarioAdmin = c.String(nullable: false, maxLength: 128),
                        codigoEmpresa = c.Int(),
                        empresa_codigo = c.Int(),
                        usuario_usuario = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.usuarioAdmin)
                .ForeignKey("dbo.Empresas", t => t.empresa_codigo)
                .ForeignKey("dbo.Usuarios", t => t.usuario_usuario)
                .Index(t => t.empresa_codigo)
                .Index(t => t.usuario_usuario);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100),
                        objetivos = c.String(maxLength: 200),
                        alcance = c.String(maxLength: 200),
                        idAdmin = c.String(),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 50),
                        codigoEmpresa = c.Int(),
                        empresa_codigo = c.Int(),
                    })
                .PrimaryKey(t => t.codigo)
                .ForeignKey("dbo.Empresas", t => t.empresa_codigo)
                .Index(t => t.empresa_codigo);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        usuario = c.String(nullable: false, maxLength: 128),
                        contraseña = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.usuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Administradors", "usuario_usuario", "dbo.Usuarios");
            DropForeignKey("dbo.Administradors", "empresa_codigo", "dbo.Empresas");
            DropForeignKey("dbo.Departamentoes", "empresa_codigo", "dbo.Empresas");
            DropIndex("dbo.Departamentoes", new[] { "empresa_codigo" });
            DropIndex("dbo.Administradors", new[] { "usuario_usuario" });
            DropIndex("dbo.Administradors", new[] { "empresa_codigo" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Departamentoes");
            DropTable("dbo.Empresas");
            DropTable("dbo.Administradors");
        }
    }
}
