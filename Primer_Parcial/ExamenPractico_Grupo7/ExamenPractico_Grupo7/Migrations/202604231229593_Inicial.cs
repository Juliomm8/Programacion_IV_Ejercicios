namespace ExamenPractico_Grupo7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guerreroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Raza = c.String(nullable: false, maxLength: 50),
                        NivelPoder = c.Int(nullable: false),
                        Transformacion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tecnicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreTecnica = c.String(nullable: false, maxLength: 50),
                        Tipo = c.String(nullable: false, maxLength: 50),
                        NivelDano = c.Int(nullable: false),
                        GuerreroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guerreroes", t => t.GuerreroId, cascadeDelete: true)
                .Index(t => t.GuerreroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tecnicas", "GuerreroId", "dbo.Guerreroes");
            DropIndex("dbo.Tecnicas", new[] { "GuerreroId" });
            DropTable("dbo.Tecnicas");
            DropTable("dbo.Guerreroes");
        }
    }
}
