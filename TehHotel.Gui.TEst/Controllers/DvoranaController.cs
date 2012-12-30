using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.Test.Models;
using TehHotel.Gui.Test.RezervacijaService;

namespace TehHotel.Gui.Test.Controllers
{
    public class DvoranaController : Controller
    {
        //
        // GET: /Dvorana/

        public ActionResult Index()
        {
            this.ModelState.Clear();
            return View("Rezervacija");
        }

        [HttpPost]
        public ActionResult MozneRezervacijeDvorane(RezervacijaPosebneStoritve model)
        {

            if (ModelState.IsValid)
            {
                List<Dvorana> mozne_rez = new RezervacijaService.RezervacijaService().ListMozneRezervacijeDvorane(model.idStoritve, true, model.datumOd, true, model.datumDo, true).ToList();
                ViewBag.Data = mozne_rez;
                return View("MozneRezervacije");
            }
            return View("Rezervacija");
        }

        [HttpPost]
        public ActionResult ShraniRezervacijoDvorane(RezervacijaPosebneStoritve model)
        {
            if (ModelState.IsValid)
            {
                int dvoranaId = model.idStoritve;
                List<RezervacijaPosebneStoritve> dvo_list = null;
                if (Session["dvorane"] == null)
                {
                    dvo_list = new List<RezervacijaPosebneStoritve>();
                    dvo_list.Add(model);
                }
                else
                {

                    dvo_list = (List<RezervacijaPosebneStoritve>)Session["dvorane"];
                    Boolean obstaja = false;
                    foreach (RezervacijaPosebneStoritve rps in dvo_list)
                    {
                        if (rps.idStoritve == dvoranaId && ((rps.datumOd < model.datumOd && rps.datumDo > model.datumDo) ||
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
                        dvo_list.Add(model);
                    }
                }
                Session["dvorane"] = dvo_list;
            }
            else
            {
                View("MozneRezervacije");
            }
            this.ModelState.Clear();
            return RedirectToAction("Index");
        }

    }
}
