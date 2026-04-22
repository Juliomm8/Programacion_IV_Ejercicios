namespace ExamenPracticoRoblox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Avatars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false, maxLength: 50),
                        Juego = c.String(nullable: false, maxLength: 100),
                        NivelExperiencia = c.Int(nullable: false),
                        HabilidadEspecial = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreItem = c.String(nullable: false, maxLength: 100),
                        Categoria = c.String(nullable: false, maxLength: 50),
                        PrecioRobux = c.Int(nullable: false),
                        AvatarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Avatars", t => t.AvatarId, cascadeDelete: true)
                .Index(t => t.AvatarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "AvatarId", "dbo.Avatars");
            DropIndex("dbo.Items", new[] { "AvatarId" });
            DropTable("dbo.Items");
            DropTable("dbo.Avatars");
        }
    }
}
