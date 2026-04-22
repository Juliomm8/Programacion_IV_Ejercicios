namespace ExamenPracticoSailorMoon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aliadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreAliado = c.String(nullable: false, maxLength: 50),
                        Tipo = c.String(nullable: false, maxLength: 50),
                        Edad = c.Int(nullable: false),
                        SailorSenshiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SailorSenshis", t => t.SailorSenshiId, cascadeDelete: true)
                .Index(t => t.SailorSenshiId);
            
            CreateTable(
                "dbo.SailorSenshis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Planeta = c.String(nullable: false, maxLength: 50),
                        NivelPoder = c.Int(nullable: false),
                        HabilidadEspecial = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aliadoes", "SailorSenshiId", "dbo.SailorSenshis");
            DropIndex("dbo.Aliadoes", new[] { "SailorSenshiId" });
            DropTable("dbo.SailorSenshis");
            DropTable("dbo.Aliadoes");
        }
    }
}
