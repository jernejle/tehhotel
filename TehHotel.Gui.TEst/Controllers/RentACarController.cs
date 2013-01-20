using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.Test.Models;

namespace TehHotel.Gui.Test.Controllers
{
    public class RentACarController : Controller
    {

        RentACarVozilaService.Vozila clientVozilaRC = new RentACarVozilaService.Vozila();
        RentACarRezervacijeService.Rezervacije clientRezervacijeRC = new RentACarRezervacijeService.Rezervacije();
        RentACarStrankeService.Stranke clientStrankeRC = new RentACarStrankeService.Stranke();
        StrankaService.StrankaService clientStranka = new StrankaService.StrankaService();

        //
        // GET: /RentACar/

        public ActionResult Index()
        {
            return View("Izposoja", new RentACarModel()); ;
        }

        [HttpPost]
        public ActionResult Rezervacija(RentACarModel m)
        {
            Debug.WriteLine(m.IdVozilo);
            Debug.WriteLine(m.IdStranka);
            if (ModelState.IsValid)
            {
                int strankaRCId = -1;

                StrankaService.Stranka stranka = clientStranka.ReadStranka(m.IdStranka, true);
                foreach (RentACarStrankeService.Stranka s in clientStrankeRC.pregledVsehStrank().ToList())
                {
                    if (stranka.Identifikacija.Vrednost == s.Emso)
                    {
                        strankaRCId = s.Idstranka;
                        break;
                    }
                }

                RentACarRezervacijeService.Rezervacija r = new RentACarRezervacijeService.Rezervacija();

                if (strankaRCId > 0)
                {
                    r.IdStranka = strankaRCId;
                }
                else
                {
                    string drzava = (stranka.Naslov.Drzava != null) ? stranka.Naslov.Drzava : "";
                    string emso = (stranka.Identifikacija.Vrednost != null) ? stranka.Identifikacija.Vrednost : "";
                    string ime = (stranka.Ime != null) ? stranka.Ime : "";
                    string priimek = (stranka.Priimek != null) ? stranka.Priimek : "";
                    string ulica = (stranka.Naslov.Ulica != null) ? stranka.Naslov.Ulica : "";
                    string kraj = (stranka.Naslov.Kraj != null) ? stranka.Naslov.Kraj : "";

                    string resultcreateStranka = clientStrankeRC.dodajStranko(new RentACarStrankeService.Stranka
                    {
                        Drzava = drzava,
                        Email = "",
                        Emso = emso,
                        Ime = ime,
                        Priimek = priimek,
                        Ulica = ulica,
                        Telefon = "",
                        Kraj = kraj,
                        PostnaStevilka = stranka.Naslov.PostnaStevilka
                    });
                    foreach (RentACarStrankeService.Stranka s in clientStrankeRC.pregledVsehStrank().ToList())
                    {
                        if (s.Emso == emso && s.Ime == ime && s.Priimek == priimek)
                        {
                            strankaRCId = s.Idstranka;
                            break;
                        }
                    }
                    r.IdStranka = strankaRCId;
                }
                r.IdVozilo = m.IdVozilo;

                int poslovalnicaRCId = -1;
                foreach (RentACarVozilaService.Vozilo v in clientVozilaRC.pregledRazpolozljivihVozil().ToList())
                {
                    if (v.IdVozilo == m.IdVozilo)
                    {
                        poslovalnicaRCId = v.IdPoslovalnica;
                    }
                }
                r.PrevzemIdPoslovalnica = poslovalnicaRCId;
                r.VraciloIdPoslovalnica = poslovalnicaRCId;
                string resultRezervacija = clientRezervacijeRC.dodajRezervacijo(r);
                ViewBag.result = resultRezervacija;
                return View("IzposojaResult");
            }
            return View("Izposoja", new RentACarModel());
        }

    }
}
