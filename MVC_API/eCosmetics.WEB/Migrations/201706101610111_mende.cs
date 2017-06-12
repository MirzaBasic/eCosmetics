namespace eCosmetics.WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mende : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Komentars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        KorisnikId = c.Int(nullable: false),
                        ProizvodId = c.Int(nullable: false),
                        DatumKreiranja = c.DateTime(nullable: false),
                        Sadrzaj = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.KorisnikId)
                .ForeignKey("dbo.Proizvods", t => t.ProizvodId)
                .Index(t => t.KorisnikId)
                .Index(t => t.ProizvodId);
            
            CreateTable(
                "dbo.Ocjenas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        KorisnikId = c.Int(nullable: false),
                        ProizvodId = c.Int(nullable: false),
                        DatumKreiranja = c.DateTime(nullable: false),
                        OcjenaKorisnika = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.KorisnikId)
                .ForeignKey("dbo.Proizvods", t => t.ProizvodId)
                .Index(t => t.KorisnikId)
                .Index(t => t.ProizvodId);
            
            AddColumn("dbo.Narudzbas", "BrojNarudzbe", c => c.String());
            AddColumn("dbo.Proizvods", "Ocjena", c => c.Single(nullable: false));
            AddColumn("dbo.Proizvods", "Sifra", c => c.String());
            AddColumn("dbo.Proizvods", "Akcija", c => c.Boolean(nullable: false));
            AddColumn("dbo.Proizvods", "Popust", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ocjenas", "ProizvodId", "dbo.Proizvods");
            DropForeignKey("dbo.Ocjenas", "KorisnikId", "dbo.Korisniks");
            DropForeignKey("dbo.Komentars", "ProizvodId", "dbo.Proizvods");
            DropForeignKey("dbo.Komentars", "KorisnikId", "dbo.Korisniks");
            DropIndex("dbo.Ocjenas", new[] { "ProizvodId" });
            DropIndex("dbo.Ocjenas", new[] { "KorisnikId" });
            DropIndex("dbo.Komentars", new[] { "ProizvodId" });
            DropIndex("dbo.Komentars", new[] { "KorisnikId" });
            DropColumn("dbo.Proizvods", "Popust");
            DropColumn("dbo.Proizvods", "Akcija");
            DropColumn("dbo.Proizvods", "Sifra");
            DropColumn("dbo.Proizvods", "Ocjena");
            DropColumn("dbo.Narudzbas", "BrojNarudzbe");
            DropTable("dbo.Ocjenas");
            DropTable("dbo.Komentars");
        }
    }
}
