using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.Test.Models;
using TehHotel.Gui.Test.Objects;
using TehHotel.Gui.Test.RezervacijaService;

namespace TehHotel.Gui.Test.Controllers
{
    public class SobaController : Controller
    {
        //
        // GET: /Rezervacija/

        public ActionResult Index()
        {
            ViewBag.hoteli = ListHotel();
            return View("Rezervacija");
        }

        //
        // POST: /Rezervacija/MozneRezervacijeSobe
        [HttpPost]
        public ActionResult MozneRezervacije(RezervacijaSobeObj r)
        {
            if (ModelState.IsValid)
            {
                RezervacijaService.RezervacijaService client = new RezervacijaService.RezervacijaService();
                PreveriAtribute(r.Fos);
                Soba[] sobe = client.ListMozneRezervacijeSobe(r.HotelId, true, r.DatumOd, true, r.DatumDo, true, r.Fos);
                ViewBag.sobe = sobe;
                ViewBag.rezervacijaSobe = r;
                return View("MozneRezervacije");
            }
            ViewBag.hoteli = ListHotel();
            return View(r);

        }

        [HttpPost]
        public ActionResult ShraniRezervacijoSobe(RezervacijaPosebneStoritve model)
        {
            try
            {
                
                List<RezervacijaPosebneStoritve> sobe_list = null;
                if (Session["sobe"] == null)
                {
                    sobe_list = new List<RezervacijaPosebneStoritve>();
                    sobe_list.Add(model);
                }
                else
                {
                    sobe_list = (List<RezervacijaPosebneStoritve>)Session["sobe"];
                    Boolean obstaja = false;
                    foreach (RezervacijaPosebneStoritve rps in sobe_list)
                    {
                        if (rps.idStoritve == model.idStoritve && ((rps.datumOd < model.datumOd && rps.datumDo > model.datumDo) ||
                            (rps.datumOd >= model.datumOd && rps.datumDo <= model.datumDo) ||
                            (rps.datumOd >= model.datumOd && rps.datumOd <= model.datumDo) ||
                            (rps.datumDo <= model.datumDo && rps.datumDo >= model.datumOd)))
                        {
                            obstaja = true;
                            break;
                        }
                    }
                    if (!obstaja)
                    {
                        sobe_list.Add(model);
                    }
                }
                Session["sobe"] = sobe_list;
                
            }
            catch (Exception e)
            {
                Response.Write(e.InnerException);
            }
            return RedirectToAction("Index");
        }

        public HotelService.Hotel[] ListHotel()
        {
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
