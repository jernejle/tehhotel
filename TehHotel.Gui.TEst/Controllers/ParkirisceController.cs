﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.Test.Models;
using TehHotel.Gui.Test.RezervacijaService;

namespace TehHotel.Gui.Test.Controllers
{
    public class ParkirisceController : Controller
    {
        //
        // GET: /Parkirisce/

        public ActionResult Index()
        {
            this.ModelState.Clear();
            return View("Rezervacija");
        }

        [HttpPost]
        public ActionResult MozneRezervacije(RezervacijaPosebneStoritve model)
        {
            if (ModelState.IsValid)
            {
                List<Parkirisce> mozne_rez = new RezervacijaService.RezervacijaService().ListMozneRezervacijeParkirisca(model.idStoritve, true, model.datumOd, true, model.datumDo, true).ToList();
                ViewBag.Data = mozne_rez;
                return View("MozneRezervacije");
            }
                
            return View("Rezervacija");
        }

        [HttpPost]
        public ActionResult ShraniRezervacijoParkirisca(RezervacijaPosebneStoritve model)
        {

            if (ModelState.IsValid)
            {
                int parkirisceId = model.idStoritve;
                List<RezervacijaPosebneStoritve> park_list = null;
                if (Session["parkirisca"] == null)
                {
                    park_list = new List<RezervacijaPosebneStoritve>();
                    park_list.Add(model);
                }
                else
                {

                    park_list = (List<RezervacijaPosebneStoritve>)Session["parkirisca"];
                    Boolean obstaja = false;
                    foreach (RezervacijaPosebneStoritve rps in park_list)
                    {
                        if (rps.idStoritve == parkirisceId)
                        {
                            obstaja = true;
                            break;
                        }
                    }
                    if (!obstaja)
                    {
                        park_list.Add(model);
                    }
                }
                Session["parkirisca"] = park_list;
                return RedirectToAction("Index");
            }
            return View("MozneRezervacije");
        }

    }
}