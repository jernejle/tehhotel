using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.Test.RezervacijaService;

namespace TehHotel.Gui.Test.Controllers
{
    public class RacunController : Controller
    {
        //
        // GET: /Racun/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Stranka(int id)
        {
            List<Racun> racuni = new RezervacijaService.RezervacijaService().ListRacun(id, true).ToList();
            if (racuni.Count == 0) return RedirectToAction("Index","Stranka");
            ViewData["racuni"] = racuni;
            return View("Racuni");
        }

        public ActionResult Podrobnosti(int id)
        {
            Racun racun = new RezervacijaService.RezervacijaService().ReadRacun(id, true);
            if (racun == null) return RedirectToAction("Index", "Stranka");
            ViewData["racun"] = racun;
            TempData["racun"] = racun;
            if (TempData["odgovor"] != null)
                ViewData["odgovor"] = TempData["odgovor"];

            BankaService.IzdaniRacun[] neplacani = new BankaService.KBPStranke().pregledNeplacanihIzdanihRacunov("SI56251000000001200");
            
            if (neplacani != null)
            {
                foreach (BankaService.IzdaniRacun r in neplacani)
                {
                    if (r.Racun.StevilkaRacuna == id)
                    {
                        ViewData["izdanPriBanki"] = true;
                        break;
                    }
                }
            }

            return View("Podrobnosti");
        }

        public ActionResult PodrobnostiStranka(int strankaId)
        {
            Racun racun = new RezervacijaService.RezervacijaService().ReadRacunStranka(strankaId, true);
            if (racun == null) return RedirectToAction("Index", "Stranka");
            ViewData["racun"] = racun;
            TempData["racun"] = racun;
            return View("Podrobnosti");
        }

        [HttpPost]
        public ActionResult Posreduj(FormCollection formValues)
        {
            string trr = formValues["trr"];
            int racunId = Convert.ToInt32(formValues["racunId"]);
            if (trr != null && TempData["racun"] != null)
            {
                Racun rac = (Racun) TempData["racun"];

                BankaService.KBPStranke client = new BankaService.KBPStranke();
                BankaService.IzdaniRacun racun = new BankaService.IzdaniRacun();
                racun.Racun = new BankaService.IzdaniRacunRacun();
                racun.Racun.DatumRacuna = rac.DatumRacuna;

                racun.Racun.Izdajatelj = new BankaService.IzdaniRacunRacunIzdajatelj();
                racun.Racun.Izdajatelj.FinancniPodatki = new BankaService.IzdaniRacunRacunIzdajateljFinancniPodatki();
                racun.Racun.Izdajatelj.FinancniPodatki.BancniRacun = new BankaService.IzdaniRacunRacunIzdajateljFinancniPodatkiBancniRacun();
                racun.Racun.Izdajatelj.FinancniPodatki.BancniRacun.StevilkaBancnegaRacuna = "SI56251000000001200";

                racun.Racun.Lokacija = "Maribor";
                racun.Racun.PlacilniRok = rac.DatumRacuna.AddDays(30);
                int stPostavk = 0;
                stPostavk += rac.RezervacijeDvorane.Count();
                stPostavk += rac.RezervacijeParkirisca.Count();
                stPostavk += rac.RezervacijeSob.Count();

                racun.Racun.PostavkeRacuna = new BankaService.IzdaniRacunRacunPostavka[stPostavk];
                int i = 0;
                foreach (RezervacijaSobe r in rac.RezervacijeSob)
                {
                    racun.Racun.PostavkeRacuna[i] = new BankaService.IzdaniRacunRacunPostavka();
                    racun.Racun.PostavkeRacuna[i].CenaEnote = Convert.ToDecimal(r.Soba.Cena);
                    racun.Racun.PostavkeRacuna[i].DavkiNaPostavki = new BankaService.IzdaniRacunRacunPostavkaDavkiNaPostavki();
                    racun.Racun.PostavkeRacuna[i].DavkiNaPostavki.OdstotekDavkaPostavke = 10;
                    racun.Racun.PostavkeRacuna[i].DavkiNaPostavki.ZnesekDavkaPostavke = 10;
                    racun.Racun.PostavkeRacuna[i].Opis = "TEHHOTEL: Najem sobe " + r.Soba.Stevilka;
                    racun.Racun.PostavkeRacuna[i].KolicinaArtikla = new BankaService.IzdaniRacunRacunPostavkaKolicinaArtikla();
                    racun.Racun.PostavkeRacuna[i].KolicinaArtikla.EnotaMere = "Dan";
                    TimeSpan span = r.DatumDo.Subtract(r.DatumOd);
                    racun.Racun.PostavkeRacuna[i].KolicinaArtikla.Kolicina = (span.Days > 0) ? span.Days:1;

                    racun.Racun.PostavkeRacuna[i].ZnesekPostavke = racun.Racun.PostavkeRacuna[i].CenaEnote * Convert.ToDecimal(racun.Racun.PostavkeRacuna[i].KolicinaArtikla.Kolicina);

                    i++;
                }

                foreach (RezervacijaDvorane d in rac.RezervacijeDvorane)
                {
                    racun.Racun.PostavkeRacuna[i] = new BankaService.IzdaniRacunRacunPostavka();
                    racun.Racun.PostavkeRacuna[i].CenaEnote = Convert.ToDecimal(d.Cena);
                    racun.Racun.PostavkeRacuna[i].DavkiNaPostavki = new BankaService.IzdaniRacunRacunPostavkaDavkiNaPostavki();
                    racun.Racun.PostavkeRacuna[i].DavkiNaPostavki.OdstotekDavkaPostavke = 10;
                    racun.Racun.PostavkeRacuna[i].DavkiNaPostavki.ZnesekDavkaPostavke = 10;
                    racun.Racun.PostavkeRacuna[i].Opis = "TEHHOTEL: Najem dvorane " + d.Dvorana.IdDvorana;

                    racun.Racun.PostavkeRacuna[i].KolicinaArtikla = new BankaService.IzdaniRacunRacunPostavkaKolicinaArtikla();
                    racun.Racun.PostavkeRacuna[i].KolicinaArtikla.EnotaMere = "Dan";
                    TimeSpan span = d.DatumDo.Subtract(d.DatumOd);
                    racun.Racun.PostavkeRacuna[i].KolicinaArtikla.Kolicina = (span.Days > 0) ? span.Days : 1;

                    racun.Racun.PostavkeRacuna[i].ZnesekPostavke = racun.Racun.PostavkeRacuna[i].CenaEnote * Convert.ToDecimal(racun.Racun.PostavkeRacuna[i].KolicinaArtikla.Kolicina);
                    i++;
                }

                foreach (RezervacijaParkirisca p in rac.RezervacijeParkirisca)
                {
                    racun.Racun.PostavkeRacuna[i] = new BankaService.IzdaniRacunRacunPostavka();
                    racun.Racun.PostavkeRacuna[i].CenaEnote = Convert.ToDecimal(p.Cena);
                    racun.Racun.PostavkeRacuna[i].DavkiNaPostavki = new BankaService.IzdaniRacunRacunPostavkaDavkiNaPostavki();
                    racun.Racun.PostavkeRacuna[i].DavkiNaPostavki.OdstotekDavkaPostavke = 10;
                    racun.Racun.PostavkeRacuna[i].DavkiNaPostavki.ZnesekDavkaPostavke = 10;
                    racun.Racun.PostavkeRacuna[i].Opis = "TEHHOTEL: Najem parkirišča " + p.Parkirisce.IdParkirisce;

                    racun.Racun.PostavkeRacuna[i].KolicinaArtikla = new BankaService.IzdaniRacunRacunPostavkaKolicinaArtikla();
                    racun.Racun.PostavkeRacuna[i].KolicinaArtikla.EnotaMere = "Dan";
                    TimeSpan span = p.DatumDo.Subtract(p.DatumOd);
                    racun.Racun.PostavkeRacuna[i].KolicinaArtikla.Kolicina = (span.Days > 0) ? span.Days : 1;

                    racun.Racun.PostavkeRacuna[i].ZnesekPostavke = racun.Racun.PostavkeRacuna[i].CenaEnote * Convert.ToDecimal(racun.Racun.PostavkeRacuna[i].KolicinaArtikla.Kolicina);
                    i++;
                }

                racun.Racun.PovzetekZneskovRacuna = new BankaService.IzdaniRacunRacunPovzetekZneskovRacuna();
                racun.Racun.PovzetekZneskovRacuna.Davek = 10;
                racun.Racun.PovzetekZneskovRacuna.OsnovaZaDavek = 10;
                racun.Racun.PovzetekZneskovRacuna.ZnesekRacuna = rac.SkupnaCena;

                racun.Racun.Prejemnik = new BankaService.IzdaniRacunRacunPrejemnik();
                racun.Racun.Prejemnik.FinancniPodatki = new BankaService.IzdaniRacunRacunPrejemnikFinancniPodatki();
                racun.Racun.Prejemnik.FinancniPodatki.BancniRacun = new BankaService.IzdaniRacunRacunPrejemnikFinancniPodatkiBancniRacun();
                racun.Racun.Prejemnik.FinancniPodatki.BancniRacun.StevilkaBancnegaRacuna = trr;

                
                racun.Racun.StevilkaRacuna = (ushort) rac.IdRacun;

                racun.Racun.Valuta = "EUR";

                BankaService.Odgovor o = client.izdajRacun(racun);
                TempData["odgovor"] = o.Status;
            }

            return RedirectToAction("Podrobnosti", new { id = racunId });
        }

    }
}
