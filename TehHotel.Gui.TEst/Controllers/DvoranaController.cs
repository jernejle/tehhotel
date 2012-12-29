using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.Test.RezervacijaService;

namespace TehHotel.Gui.Test.Controllers
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
            try
            {
                int hotelId = Convert.ToInt32(form["hotelId"]);
                DateTime datumod = Convert.ToDateTime(form["datumod"]);
                DateTime datumdo = Convert.ToDateTime(form["datumdo"]);
                List<Dvorana> mozne_rez = new RezervacijaService.RezervacijaService().ListMozneRezervacijeDvorane(hotelId, true, datumod, true, datumdo, true).ToList();
                ViewBag.Data = mozne_rez;
            }
            catch (Exception e)
            {
                Response.Write(e.InnerException);

            }
            return View("MozneRezervacije");
        }

        [HttpPost]
        public ActionResult ShraniRezervacijoDvorane(FormCollection form)
        {
            try
            {
                int dvoranaId = Convert.ToInt32(form["dvorana"]);
                List<int> dvo_list = null;
                if (Session["dvorane"] == null)
                {
                    dvo_list = new List<int>();
                    dvo_list.Add(dvoranaId);
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
                            break;
                        }
                    }
                    if (!obstaja)
                    {
                        dvo_list.Add(dvoranaId);
                    }
                }
                Session["dvorane"] = dvo_list;
            }
            catch (Exception e) {
                Response.Write(e.InnerException);
            }
             return RedirectToAction("Index");
        }

    }
}
