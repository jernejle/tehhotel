using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.TEst.RezervacijaService;

namespace TehHotel.Gui.TEst.Controllers
{
    public class DvoranaController : Controller
    {
        //
        // GET: /Dvorana/

        public ActionResult Index()
        {
            return View("Rezervacija");
        }

        [HttpPost]
        public ActionResult MozneRezervacijeDvorane(FormCollection form)
        {
            int hotelId = Convert.ToInt32(form["hotelId"]);
            DateTime datumod = Convert.ToDateTime(form["datumod"]);
            DateTime datumdo = Convert.ToDateTime(form["datumdo"]);
            List<Dvorana> mozne_rez = new RezervacijaService.RezervacijaService().ListMozneRezervacijeDvorane(hotelId,true,datumod,true,datumdo,true).ToList();
            ViewBag.Data = mozne_rez;
            return View("MozneRezervacije");
        }

        [HttpPost]
        public ActionResult ShraniRezervacijoDvorane(FormCollection form)
        {
            int dvoranaId = Convert.ToInt32(form["dvorana"]);
             List<int> dvo_list = null;
             if (Session["dvorane"] == null)
             {
                 dvo_list = new List<int>();
                 dvo_list.Add(dvoranaId);
                 Console.WriteLine("ustvarim novega");
             }
             else
             {

                 dvo_list = (List<int>)Session["dvorane"];
                 Boolean obstaja = false;
                 foreach (int id in dvo_list)
                 {
                     if (id == dvoranaId)
                     {
                         obstaja = true;
                         Console.WriteLine("že obstaja");
                         break;
                     }
                 }
                 if (!obstaja)
                 {
                     dvo_list.Add(dvoranaId);
                     Console.WriteLine("ne obstaja");
                 }
             }
             Session["dvorane"] = dvo_list;
             return Content("to");
        }

    }
}
