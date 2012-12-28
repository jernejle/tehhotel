namespace TehHotel.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DvoranaEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Povrsina = c.Double(nullable: false),
                        StLjudi = c.Int(nullable: false),
                        HotelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HotelEFs", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.HotelEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Zvezdice = c.Int(nullable: false),
                        Kuhinja = c.Boolean(nullable: false),
                        Bazen = c.Boolean(nullable: false),
                        NaslovId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NaslovEFs", t => t.NaslovId)
                .Index(t => t.NaslovId);
            
            CreateTable(
                "dbo.NaslovEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Drzava = c.String(),
                        PostnaStevilka = c.Int(nullable: false),
                        Kraj = c.String(),
                        Ulica = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ZaposleniEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Vloga = c.String(),
                        Ime = c.String(),
                        Priimek = c.String(),
                        Spol = c.String(),
                        DatumRojstva = c.DateTime(),
                        Izobrazba = c.String(),
                        DatumZaposlitve = c.DateTime(),
                        Telefon = c.Int(),
                        NaslovId = c.Int(),
                        IdentifikacijaId = c.Int(),
                        HotelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NaslovEFs", t => t.NaslovId)
                .ForeignKey("dbo.IdentifikacijaEFs", t => t.IdentifikacijaId)
                .ForeignKey("dbo.HotelEFs", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.NaslovId)
                .Index(t => t.IdentifikacijaId)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.IdentifikacijaEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tip = c.String(),
                        Vrednost = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ParkirisceEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stevilka = c.String(),
                        Pokrito = c.Boolean(nullable: false),
                        HotelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HotelEFs", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.SobaEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stevilka = c.Int(nullable: false),
                        StPostelj = c.Int(nullable: false),
                        Cena = c.Double(nullable: false),
                        Valuta = c.String(),
                        Balkon = c.Boolean(nullable: false),
                        Internet = c.Boolean(nullable: false),
                        Hladilnik = c.Boolean(nullable: false),
                        Televizija = c.Boolean(nullable: false),
                        Nadstropje = c.Int(nullable: false),
                        HotelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HotelEFs", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.StrankaEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Priimek = c.String(),
                        DatumRojstva = c.DateTime(nullable: false),
                        NaslovId = c.Int(),
                        IdentifikacijaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NaslovEFs", t => t.NaslovId)
                .ForeignKey("dbo.IdentifikacijaEFs", t => t.IdentifikacijaId)
                .Index(t => t.NaslovId)
                .Index(t => t.IdentifikacijaId);
            
            CreateTable(
                "dbo.RezervacijaSobeEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumOd = c.DateTime(nullable: false),
                        DatumDo = c.DateTime(nullable: false),
                        HotelId = c.Int(),
                        StrankaId = c.Int(),
                        SobaId = c.Int(),
                        Hrana = c.String(),
                        RacunEF_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HotelEFs", t => t.HotelId)
                .ForeignKey("dbo.StrankaEFs", t => t.StrankaId)
                .ForeignKey("dbo.SobaEFs", t => t.SobaId)
                .ForeignKey("dbo.RacunEFs", t => t.RacunEF_Id)
                .Index(t => t.HotelId)
                .Index(t => t.StrankaId)
                .Index(t => t.SobaId)
                .Index(t => t.RacunEF_Id);
            
            CreateTable(
                "dbo.RacunEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StevilkaRacuna = c.Int(nullable: false),
                        DatumRacuna = c.DateTime(nullable: false),
                        Valuta = c.String(),
                        SkupnaCena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Placano = c.Boolean(nullable: false),
                        StrankaId = c.Int(nullable: false),
                        HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StrankaEFs", t => t.StrankaId, cascadeDelete: true)
                .ForeignKey("dbo.HotelEFs", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.StrankaId)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.RezervacijaDvoraneEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SteviloLjudi = c.Int(nullable: false),
                        DvoranaId = c.Int(nullable: false),
                        StrankaId = c.Int(nullable: false),
                        ImePosebneStoritve = c.String(),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatumOd = c.DateTime(nullable: false),
                        DatumDo = c.DateTime(nullable: false),
                        RacunEF_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DvoranaEFs", t => t.DvoranaId, cascadeDelete: true)
                .ForeignKey("dbo.StrankaEFs", t => t.StrankaId, cascadeDelete: true)
                .ForeignKey("dbo.RacunEFs", t => t.RacunEF_Id)
                .Index(t => t.DvoranaId)
                .Index(t => t.StrankaId)
                .Index(t => t.RacunEF_Id);
            
            CreateTable(
                "dbo.RezervacijaParkiriscaEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParkirisceId = c.Int(nullable: false),
                        StrankaId = c.Int(nullable: false),
                        ImePosebneStoritve = c.String(),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatumOd = c.DateTime(nullable: false),
                        DatumDo = c.DateTime(nullable: false),
                        RacunEF_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ParkirisceEFs", t => t.ParkirisceId, cascadeDelete: true)
                .ForeignKey("dbo.StrankaEFs", t => t.StrankaId, cascadeDelete: true)
                .ForeignKey("dbo.RacunEFs", t => t.RacunEF_Id)
                .Index(t => t.ParkirisceId)
                .Index(t => t.StrankaId)
                .Index(t => t.RacunEF_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.RezervacijaParkiriscaEFs", new[] { "RacunEF_Id" });
            DropIndex("dbo.RezervacijaParkiriscaEFs", new[] { "StrankaId" });
            DropIndex("dbo.RezervacijaParkiriscaEFs", new[] { "ParkirisceId" });
            DropIndex("dbo.RezervacijaDvoraneEFs", new[] { "RacunEF_Id" });
            DropIndex("dbo.RezervacijaDvoraneEFs", new[] { "StrankaId" });
            DropIndex("dbo.RezervacijaDvoraneEFs", new[] { "DvoranaId" });
            DropIndex("dbo.RacunEFs", new[] { "HotelId" });
            DropIndex("dbo.RacunEFs", new[] { "StrankaId" });
            DropIndex("dbo.RezervacijaSobeEFs", new[] { "RacunEF_Id" });
            DropIndex("dbo.RezervacijaSobeEFs", new[] { "SobaId" });
            DropIndex("dbo.RezervacijaSobeEFs", new[] { "StrankaId" });
            DropIndex("dbo.RezervacijaSobeEFs", new[] { "HotelId" });
            DropIndex("dbo.StrankaEFs", new[] { "IdentifikacijaId" });
            DropIndex("dbo.StrankaEFs", new[] { "NaslovId" });
            DropIndex("dbo.SobaEFs", new[] { "HotelId" });
            DropIndex("dbo.ParkirisceEFs", new[] { "HotelId" });
            DropIndex("dbo.ZaposleniEFs", new[] { "HotelId" });
            DropIndex("dbo.ZaposleniEFs", new[] { "IdentifikacijaId" });
            DropIndex("dbo.ZaposleniEFs", new[] { "NaslovId" });
            DropIndex("dbo.HotelEFs", new[] { "NaslovId" });
            DropIndex("dbo.DvoranaEFs", new[] { "HotelId" });
            DropForeignKey("dbo.RezervacijaParkiriscaEFs", "RacunEF_Id", "dbo.RacunEFs");
            DropForeignKey("dbo.RezervacijaParkiriscaEFs", "StrankaId", "dbo.StrankaEFs");
            DropForeignKey("dbo.RezervacijaParkiriscaEFs", "ParkirisceId", "dbo.ParkirisceEFs");
            DropForeignKey("dbo.RezervacijaDvoraneEFs", "RacunEF_Id", "dbo.RacunEFs");
            DropForeignKey("dbo.RezervacijaDvoraneEFs", "StrankaId", "dbo.StrankaEFs");
            DropForeignKey("dbo.RezervacijaDvoraneEFs", "DvoranaId", "dbo.DvoranaEFs");
            DropForeignKey("dbo.RacunEFs", "HotelId", "dbo.HotelEFs");
            DropForeignKey("dbo.RacunEFs", "StrankaId", "dbo.StrankaEFs");
            DropForeignKey("dbo.RezervacijaSobeEFs", "RacunEF_Id", "dbo.RacunEFs");
            DropForeignKey("dbo.RezervacijaSobeEFs", "SobaId", "dbo.SobaEFs");
            DropForeignKey("dbo.RezervacijaSobeEFs", "StrankaId", "dbo.StrankaEFs");
            DropForeignKey("dbo.RezervacijaSobeEFs", "HotelId", "dbo.HotelEFs");
            DropForeignKey("dbo.StrankaEFs", "IdentifikacijaId", "dbo.IdentifikacijaEFs");
            DropForeignKey("dbo.StrankaEFs", "NaslovId", "dbo.NaslovEFs");
            DropForeignKey("dbo.SobaEFs", "HotelId", "dbo.HotelEFs");
            DropForeignKey("dbo.ParkirisceEFs", "HotelId", "dbo.HotelEFs");
            DropForeignKey("dbo.ZaposleniEFs", "HotelId", "dbo.HotelEFs");
            DropForeignKey("dbo.ZaposleniEFs", "IdentifikacijaId", "dbo.IdentifikacijaEFs");
            DropForeignKey("dbo.ZaposleniEFs", "NaslovId", "dbo.NaslovEFs");
            DropForeignKey("dbo.HotelEFs", "NaslovId", "dbo.NaslovEFs");
            DropForeignKey("dbo.DvoranaEFs", "HotelId", "dbo.HotelEFs");
            DropTable("dbo.RezervacijaParkiriscaEFs");
            DropTable("dbo.RezervacijaDvoraneEFs");
            DropTable("dbo.RacunEFs");
            DropTable("dbo.RezervacijaSobeEFs");
            DropTable("dbo.StrankaEFs");
            DropTable("dbo.SobaEFs");
            DropTable("dbo.ParkirisceEFs");
            DropTable("dbo.IdentifikacijaEFs");
            DropTable("dbo.ZaposleniEFs");
            DropTable("dbo.NaslovEFs");
            DropTable("dbo.HotelEFs");
            DropTable("dbo.DvoranaEFs");
        }
    }
}
