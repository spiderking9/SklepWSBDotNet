namespace Sklep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aktualnoscs",
                c => new
                    {
                        IdAktualnosc = c.Int(nullable: false, identity: true),
                        Tytul = c.String(nullable: false, maxLength: 30),
                        TrescAktualnosci = c.String(),
                        PozycjeWyswietlania = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAktualnosc);
            
            CreateTable(
                "dbo.Handlowiecs",
                c => new
                    {
                        IdHandlowca = c.Int(nullable: false, identity: true),
                        Imie = c.String(nullable: false),
                        Nazwisko = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.IdHandlowca);
            
            CreateTable(
                "dbo.Ogloszenies",
                c => new
                    {
                        IdOgloszenia = c.Int(nullable: false, identity: true),
                        Tytul = c.String(nullable: false, maxLength: 30),
                        TrescOgloszenia = c.String(),
                    })
                .PrimaryKey(t => t.IdOgloszenia);
            
            CreateTable(
                "dbo.Pozycjas",
                c => new
                    {
                        IdPozycja = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.IdPozycja);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Towars",
                c => new
                    {
                        IdTowar = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Opis = c.String(nullable: false),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VipTowar = c.Boolean(nullable: false),
                        TowarPromocyjny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdTowar);
            
            CreateTable(
                "dbo.TowarStans",
                c => new
                    {
                        IdStanMagazynowy = c.Int(nullable: false, identity: true),
                        Stan = c.Int(nullable: false),
                        DataDodania = c.DateTime(nullable: false),
                        IdTowar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdStanMagazynowy)
                .ForeignKey("dbo.Towars", t => t.IdTowar, cascadeDelete: true)
                .Index(t => t.IdTowar);
            
            CreateTable(
                "dbo.TowarZdjecias",
                c => new
                    {
                        IdTowarZdjecie = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        IdTowar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdTowarZdjecie)
                .ForeignKey("dbo.Towars", t => t.IdTowar, cascadeDelete: true)
                .Index(t => t.IdTowar);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TowarZdjecias", "IdTowar", "dbo.Towars");
            DropForeignKey("dbo.TowarStans", "IdTowar", "dbo.Towars");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TowarZdjecias", new[] { "IdTowar" });
            DropIndex("dbo.TowarStans", new[] { "IdTowar" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TowarZdjecias");
            DropTable("dbo.TowarStans");
            DropTable("dbo.Towars");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Pozycjas");
            DropTable("dbo.Ogloszenies");
            DropTable("dbo.Handlowiecs");
            DropTable("dbo.Aktualnoscs");
        }
    }
}
