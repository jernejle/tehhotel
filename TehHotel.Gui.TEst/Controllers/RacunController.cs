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
            return View("Podrobnosti");
        }

    }
}
