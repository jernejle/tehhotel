using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.Test.HotelService;

namespace TehHotel.Gui.Test.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /Hotel/

        public ActionResult Index()
        {
            List<Hotel> hoteli = null;
            try {
                hoteli = new HotelService.HotelService().ListHotel().ToList();
            } catch (Exception) {}
            ViewData["hoteli"] = hoteli;
            return View("Izpis");
        }

        public ActionResult Podrobnosti(int Id)
        {
            Hotel hotel = null;
            try
            {
                hotel = new HotelService.HotelService().ReadHotel(Id, true);
            }
            catch (Exception) { }
            ViewData["hotel"] = hotel;
            return View("Podrobnosti");
        }

        [HttpPost]
        public ActionResult IskanjeHotelov(FormCollection form)
        {
            String drzava = form["drzava"];
            String kraj = form["kraj"];

            if (!kraj.Equals("")) {
                ViewData["hoteli"] = new HotelService.HotelService().ListHotelByKraj(kraj).ToList();
                return View("Izpis");
            }

            if (!drzava.Equals(""))
            {
                ViewData["hoteli"] = null;
                try
                {
                    ViewData["hoteli"] = new HotelService.HotelService().ListHotelByDrzava(drzava).ToList();
                }
                catch (Exception) { }
                return View("Izpis");
            }

            return RedirectToAction("Index");

        }

    }
}
