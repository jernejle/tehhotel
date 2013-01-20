using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.Test.Models;
using TehHotel.Gui.Test.StrankaService;

namespace TehHotel.Gui.Test.Controllers
{
    public class StrankaController : Controller
    {
        //
        // GET: /Stranka/

        public ActionResult Index()
        {
            List<Stranka> stranke = new StrankaService.StrankaService().ListStranka().ToList();
            ViewData["stranke"] = stranke;
            PosodobiRacune();
            return View("Seznam");
        }

        public void PosodobiRacune()
        {
            List<BancniRacun> bancniRacuni = new List<BancniRacun>();
            bancniRacuni.Add(new BancniRacun("teh-dejan", "123456", "SI56251000000001201"));
            bancniRacuni.Add(new BancniRacun("teh-gregor", "123456", "SI56251000000001202"));
            bancniRacuni.Add(new BancniRacun("teh-jernej", "123456", "SI56251000000001203"));

            RezervacijaService.RezervacijaService rclient = new RezervacijaService.RezervacijaService();
            rclient.ListRacun(1, true);
            BankaService.KBPStranke client = new BankaService.KBPStranke();

            foreach (BancniRacun b in bancniRacuni)
            {
                client.SetUpime(b.upime);
                client.SetGeslo(b.geslo);

                BankaService.IzdaniRacun[] bankaRacuni = client.pregledPlacanihRacunov(b.trr);
                if (bankaRacuni != null)
                {
                    foreach (BankaService.IzdaniRacun bracun in bankaRacuni)
                    {
                        bool rezultat;
                        bool nekaj = true;
                        rclient.PlacajRacun(bracun.Racun.StevilkaRacuna, true, out rezultat, out nekaj);
                    }
                }
            }
        }

    }
}
