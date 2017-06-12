namespace eCosmetics.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Ime = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Prezime = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proizvods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        Opis = c.String(),
                        Slika = c.Binary(),
                        Cijena = c.Single(nullable: false),
                        TipProizvodaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipProizvodas", t => t.TipProizvodaId)
                .Index(t => t.TipProizvodaId);
            
            CreateTable(
                "dbo.TipProizvodas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Proizvods", "TipProizvodaId", "dbo.TipProizvodas");
            DropIndex("dbo.Proizvods", new[] { "TipProizvodaId" });
            DropTable("dbo.TipProizvodas");
            DropTable("dbo.Proizvods");
            DropTable("dbo.Korisniks");
        }
    }
}
