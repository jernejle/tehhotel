using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.Test.Objects;
using TehHotel.Gui.Test.RezervacijaService;

namespace TehHotel.Gui.Test.Controllers
{
    public class RezervacijaController : Controller
    {
        //
        // GET: /Rezervacija/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Rezervacija/MozneRezervacijeSobe

        public ActionResult MozneRezervacijeSobe()
        {
            ViewBag.hoteli = ListHotel();
            return View();
        }

        //
        // POST: /Rezervacija/MozneRezervacijeSobe
        [HttpPost]
        public ActionResult MozneRezervacijeSobe(RezervacijaSobeObj r)
        {
            if (ModelState.IsValid)
            {
                RezervacijaService.RezervacijaService client = new RezervacijaService.RezervacijaService();
                PreveriAtribute(r.Fos);
                Soba[] sobe = client.ListMozneRezervacijeSobe(r.HotelId, true, r.DatumOd, true, r.DatumDo, true, r.Fos);
                Debug.WriteLine(sobe.Length);
            }
            
                ViewBag.hoteli = ListHotel();
                return View(r);
            
        }

        public HotelService.Hotel[] ListHotel(){
            HotelService.HotelService client = new HotelService.HotelService();
            return client.ListHotel();
        }

        public FilterOptionsSoba PreveriAtribute(FilterOptionsSoba fos)
        {
            if (fos.Balkon != null)
                fos.BalkonSpecified = true;
            if (fos.Hladilnik != null)
                fos.HladilnikSpecified = true;
            if (fos.Internet != null)
                fos.InternetSpecified = true;
            if (fos.Nadstropje != null && fos.Nadstropje > 0)
                fos.NadstropjeSpecified = true;
            if (fos.StPostelj != null && fos.StPostelj > 0)
                fos.StPosteljSpecified = true;
            if (fos.Televizija != null)
                fos.TelevizijaSpecified = true;

            return fos;
        }
    }
}
