namespace TehHotel.Dal.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "DvoranaEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(unicode: false),
                        Povrsina = c.Double(nullable: false),
                        StLjudi = c.Int(nullable: false),
                        HotelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("HotelEFs", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.HotelId);
            
            CreateTable(
                "HotelEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(unicode: false),
                        Zvezdice = c.Int(nullable: false),
                        Kuhinja = c.Boolean(nullable: false),
                        Bazen = c.Boolean(nullable: false),
                        NaslovId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("NaslovEFs", t => t.NaslovId)
                .Index(t => t.NaslovId);
            
            CreateTable(
                "NaslovEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Drzava = c.String(unicode: false),
                        PostnaStevilka = c.Int(nullable: false),
                        Kraj = c.String(unicode: false),
                        Ulica = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ZaposleniEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Email = c.String(unicode: false),
                        Vloga = c.String(unicode: false),
                        Ime = c.String(unicode: false),
                        Priimek = c.String(unicode: false),
                        Spol = c.String(unicode: false),
                        DatumRojstva = c.DateTime(),
                        Izobrazba = c.String(unicode: false),
                        DatumZaposlitve = c.DateTime(),
                        Telefon = c.Int(),
                        NaslovId = c.Int(),
                        IdentifikacijaId = c.Int(),
                        HotelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("NaslovEFs", t => t.NaslovId)
                .ForeignKey("IdentifikacijaEFs", t => t.IdentifikacijaId)
                .ForeignKey("HotelEFs", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.NaslovId)
                .Index(t => t.IdentifikacijaId)
                .Index(t => t.HotelId);
            
            CreateTable(
                "IdentifikacijaEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tip = c.String(unicode: false),
                        Vrednost = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "ParkirisceEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stevilka = c.String(unicode: false),
                        Pokrito = c.Boolean(nullable: false),
                        HotelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("HotelEFs", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.HotelId);
            
            CreateTable(
                "SobaEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stevilka = c.Int(nullable: false),
                        StPostelj = c.Int(nullable: false),
                        Cena = c.Double(nullable: false),
                        Valuta = c.String(unicode: false),
                        Balkon = c.Boolean(nullable: false),
                        Internet = c.Boolean(nullable: false),
                        Hladilnik = c.Boolean(nullable: false),
                        Televizija = c.Boolean(nullable: false),
                        Nadstropje = c.Int(nullable: false),
                        HotelId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("HotelEFs", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.HotelId);
            
            CreateTable(
                "StrankaEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(unicode: false),
                        Priimek = c.String(unicode: false),
                        DatumRojstva = c.DateTime(nullable: false),
                        NaslovId = c.Int(),
                        IdentifikacijaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("NaslovEFs", t => t.NaslovId)
                .ForeignKey("IdentifikacijaEFs", t => t.IdentifikacijaId)
                .Index(t => t.NaslovId)
                .Index(t => t.IdentifikacijaId);
            
            CreateTable(
                "RezervacijaSobeEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumOd = c.DateTime(nullable: false),
                        DatumDo = c.DateTime(nullable: false),
                        HotelId = c.Int(),
                        StrankaId = c.Int(),
                        SobaId = c.Int(),
                        Hrana = c.String(unicode: false),
                        RacunEF_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("HotelEFs", t => t.HotelId)
                .ForeignKey("StrankaEFs", t => t.StrankaId)
                .ForeignKey("SobaEFs", t => t.SobaId)
                .ForeignKey("RacunEFs", t => t.RacunEF_Id)
                .Index(t => t.HotelId)
                .Index(t => t.StrankaId)
                .Index(t => t.SobaId)
                .Index(t => t.RacunEF_Id);
            
            CreateTable(
                "RacunEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StevilkaRacuna = c.Int(nullable: false),
                        DatumRacuna = c.DateTime(nullable: false),
                        Valuta = c.String(unicode: false),
                        SkupnaCena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Placano = c.Boolean(nullable: false),
                        StrankaId = c.Int(nullable: false),
                        HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("StrankaEFs", t => t.StrankaId, cascadeDelete: true)
                .ForeignKey("HotelEFs", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.StrankaId)
                .Index(t => t.HotelId);
            
            CreateTable(
                "RezervacijaDvoraneEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SteviloLjudi = c.Int(nullable: false),
                        DvoranaId = c.Int(nullable: false),
                        StrankaId = c.Int(nullable: false),
                        ImePosebneStoritve = c.String(unicode: false),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatumOd = c.DateTime(nullable: false),
                        DatumDo = c.DateTime(nullable: false),
                        RacunEF_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("DvoranaEFs", t => t.DvoranaId, cascadeDelete: true)
                .ForeignKey("StrankaEFs", t => t.StrankaId, cascadeDelete: true)
                .ForeignKey("RacunEFs", t => t.RacunEF_Id)
                .Index(t => t.DvoranaId)
                .Index(t => t.StrankaId)
                .Index(t => t.RacunEF_Id);
            
            CreateTable(
                "RezervacijaParkiriscaEFs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParkirisceId = c.Int(nullable: false),
                        StrankaId = c.Int(nullable: false),
                        ImePosebneStoritve = c.String(unicode: false),
                        Cena = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DatumOd = c.DateTime(nullable: false),
                        DatumDo = c.DateTime(nullable: false),
                        RacunEF_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("ParkirisceEFs", t => t.ParkirisceId, cascadeDelete: true)
                .ForeignKey("StrankaEFs", t => t.StrankaId, cascadeDelete: true)
                .ForeignKey("RacunEFs", t => t.RacunEF_Id)
                .Index(t => t.ParkirisceId)
                .Index(t => t.StrankaId)
                .Index(t => t.RacunEF_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("RezervacijaParkiriscaEFs", new[] { "RacunEF_Id" });
            DropIndex("RezervacijaParkiriscaEFs", new[] { "StrankaId" });
            DropIndex("RezervacijaParkiriscaEFs", new[] { "ParkirisceId" });
            DropIndex("RezervacijaDvoraneEFs", new[] { "RacunEF_Id" });
            DropIndex("RezervacijaDvoraneEFs", new[] { "StrankaId" });
            DropIndex("RezervacijaDvoraneEFs", new[] { "DvoranaId" });
            DropIndex("RacunEFs", new[] { "HotelId" });
            DropIndex("RacunEFs", new[] { "StrankaId" });
            DropIndex("RezervacijaSobeEFs", new[] { "RacunEF_Id" });
            DropIndex("RezervacijaSobeEFs", new[] { "SobaId" });
            DropIndex("RezervacijaSobeEFs", new[] { "StrankaId" });
            DropIndex("RezervacijaSobeEFs", new[] { "HotelId" });
            DropIndex("StrankaEFs", new[] { "IdentifikacijaId" });
            DropIndex("StrankaEFs", new[] { "NaslovId" });
            DropIndex("SobaEFs", new[] { "HotelId" });
            DropIndex("ParkirisceEFs", new[] { "HotelId" });
            DropIndex("ZaposleniEFs", new[] { "HotelId" });
            DropIndex("ZaposleniEFs", new[] { "IdentifikacijaId" });
            DropIndex("ZaposleniEFs", new[] { "NaslovId" });
            DropIndex("HotelEFs", new[] { "NaslovId" });
            DropIndex("DvoranaEFs", new[] { "HotelId" });
            DropForeignKey("RezervacijaParkiriscaEFs", "RacunEF_Id", "RacunEFs");
            DropForeignKey("RezervacijaParkiriscaEFs", "StrankaId", "StrankaEFs");
            DropForeignKey("RezervacijaParkiriscaEFs", "ParkirisceId", "ParkirisceEFs");
            DropForeignKey("RezervacijaDvoraneEFs", "RacunEF_Id", "RacunEFs");
            DropForeignKey("RezervacijaDvoraneEFs", "StrankaId", "StrankaEFs");
            DropForeignKey("RezervacijaDvoraneEFs", "DvoranaId", "DvoranaEFs");
            DropForeignKey("RacunEFs", "HotelId", "HotelEFs");
            DropForeignKey("RacunEFs", "StrankaId", "StrankaEFs");
            DropForeignKey("RezervacijaSobeEFs", "RacunEF_Id", "RacunEFs");
            DropForeignKey("RezervacijaSobeEFs", "SobaId", "SobaEFs");
            DropForeignKey("RezervacijaSobeEFs", "StrankaId", "StrankaEFs");
            DropForeignKey("RezervacijaSobeEFs", "HotelId", "HotelEFs");
            DropForeignKey("StrankaEFs", "IdentifikacijaId", "IdentifikacijaEFs");
            DropForeignKey("StrankaEFs", "NaslovId", "NaslovEFs");
            DropForeignKey("SobaEFs", "HotelId", "HotelEFs");
            DropForeignKey("ParkirisceEFs", "HotelId", "HotelEFs");
            DropForeignKey("ZaposleniEFs", "HotelId", "HotelEFs");
            DropForeignKey("ZaposleniEFs", "IdentifikacijaId", "IdentifikacijaEFs");
            DropForeignKey("ZaposleniEFs", "NaslovId", "NaslovEFs");
            DropForeignKey("HotelEFs", "NaslovId", "NaslovEFs");
            DropForeignKey("DvoranaEFs", "HotelId", "HotelEFs");
            DropTable("RezervacijaParkiriscaEFs");
            DropTable("RezervacijaDvoraneEFs");
            DropTable("RacunEFs");
            DropTable("RezervacijaSobeEFs");
            DropTable("StrankaEFs");
            DropTable("SobaEFs");
            DropTable("ParkirisceEFs");
            DropTable("IdentifikacijaEFs");
            DropTable("ZaposleniEFs");
            DropTable("NaslovEFs");
            DropTable("HotelEFs");
            DropTable("DvoranaEFs");
        }
    }
}
