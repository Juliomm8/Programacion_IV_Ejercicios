using static System.Data.Entity.Infrastructure.Design.Executor;

namespace GestionEscolarMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estudiantes", "Edad", c => c.Int(nullable: false));
            AddColumn("dbo.Estudiantes", "Carrera", c => c.String(nullable: false));
            AddColumn("dbo.Estudiantes", "Correo", c => c.String(nullable: false));
            AddColumn("dbo.Estudiantes", "Semestre", c => c.Int(nullable: false));
            AddColumn("dbo.Universidads", "Ubicacion", c => c.String(nullable: false));
            AddColumn("dbo.Universidads", "Rector", c => c.String(nullable: false));
            AddColumn("dbo.Universidads", "AñoFundacion", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Universidads", "AñoFundacion");
            DropColumn("dbo.Universidads", "Rector");
            DropColumn("dbo.Universidads", "Ubicacion");
            DropColumn("dbo.Estudiantes", "Semestre");
            DropColumn("dbo.Estudiantes", "Correo");
            DropColumn("dbo.Estudiantes", "Carrera");
            DropColumn("dbo.Estudiantes", "Edad");
        }
    }
}
