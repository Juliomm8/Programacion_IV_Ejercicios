namespace ExamenPracticoMarioBros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Enemigoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreEnemigo = c.String(nullable: false, maxLength: 50),
                        Tipo = c.String(nullable: false, maxLength: 50),
                        NivelDificultad = c.Int(nullable: false),
                        PersonajeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Personajes", t => t.PersonajeId, cascadeDelete: true)
                .Index(t => t.PersonajeId);
            
            CreateTable(
                "dbo.Personajes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Reino = c.String(nullable: false, maxLength: 50),
                        NivelPoder = c.Int(nullable: false),
                        HabilidadEspecial = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enemigoes", "PersonajeId", "dbo.Personajes");
            DropIndex("dbo.Enemigoes", new[] { "PersonajeId" });
            DropTable("dbo.Personajes");
            DropTable("dbo.Enemigoes");
        }
    }
}
