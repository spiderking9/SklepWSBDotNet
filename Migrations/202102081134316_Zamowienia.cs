namespace Sklep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Zamowienia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Zamowienies",
                c => new
                    {
                        IdZamowienie = c.Int(nullable: false, identity: true),
                        Idhandlowiec = c.Int(nullable: false),
                        Imie = c.String(nullable: false),
                        Nazwisko = c.String(nullable: false),
                        Adres = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        AdresEmail = c.String(nullable: false),
                        DataZamowienia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdZamowienie);
            
            CreateTable(
                "dbo.ZamowieniePozycjas",
                c => new
                    {
                        IdZamowieniePozycja = c.Int(nullable: false, identity: true),
                        IdTowar = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Wartosc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdZamowienie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdZamowieniePozycja)
                .ForeignKey("dbo.Towars", t => t.IdTowar, cascadeDelete: true)
                .ForeignKey("dbo.Zamowienies", t => t.IdZamowienie, cascadeDelete: true)
                .Index(t => t.IdTowar)
                .Index(t => t.IdZamowienie);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZamowieniePozycjas", "IdZamowienie", "dbo.Zamowienies");
            DropForeignKey("dbo.ZamowieniePozycjas", "IdTowar", "dbo.Towars");
            DropIndex("dbo.ZamowieniePozycjas", new[] { "IdZamowienie" });
            DropIndex("dbo.ZamowieniePozycjas", new[] { "IdTowar" });
            DropTable("dbo.ZamowieniePozycjas");
            DropTable("dbo.Zamowienies");
        }
    }
}
