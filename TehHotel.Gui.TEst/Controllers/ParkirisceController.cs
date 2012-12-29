using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.TEst.RezervacijaService;

namespace TehHotel.Gui.TEst.Controllers
{
    public class ParkirisceController : Controller
    {
        //
        // GET: /Parkirisce/

        public ActionResult Index()
        {
            return View("Rezervacija");
        }

        [HttpPost]
        public ActionResult MozneRezervacije(FormCollection form)
        {
            try
            {
                int hotelId = Convert.ToInt32(form["hotelId"]);
                DateTime datumod = Convert.ToDateTime(form["datumod"]);
                DateTime datumdo = Convert.ToDateTime(form["datumdo"]);
                List<Parkirisce> mozne_rez = new RezervacijaService.RezervacijaService().ListMozneRezervacijeParkirisca(hotelId, true, datumod, true, datumdo, true).ToList();
                ViewBag.Data = mozne_rez;
            }
            catch (Exception e)
            {
                Response.Write(e.InnerException);
            }
            return View("MozneRezervacije");
        }

        [HttpPost]
        public ActionResult ShraniRezervacijoParkirisca(FormCollection form)
        {
            try
            {
                int parkirisceId = Convert.ToInt32(form["parkirisce"]);
                Response.Write("daj no " + parkirisceId);
                List<int> park_list = null;
                if (Session["parkirisca"] == null)
                {
                    park_list = new List<int>();
                    park_list.Add(parkirisceId);
                }
                else
                {

                    park_list = (List<int>)Session["parkirisca"];
                    Boolean obstaja = false;
                    foreach (int id in park_list)
                    {
                        if (id == parkirisceId)
                        {
                            obstaja = true;
                            break;
                        }
                    }
                    if (!obstaja)
                    {
                        park_list.Add(parkirisceId);
                    }
                }
                Session["parkirisca"] = park_list;
            }
            catch (Exception e)
            {
                Response.Write(e.InnerException);
            }
            return RedirectToAction("Index");
        }

    }
}
