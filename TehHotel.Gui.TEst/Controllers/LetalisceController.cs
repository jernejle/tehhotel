using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TehHotel.Gui.Test.Controllers
{
    public class LetalisceController : Controller
    {
        //
        // GET: /Letalisce/

        public ActionResult Index()
        {
            List<SelectListItem> letalisca = null;
            try
            {
                letalisca = Helpers.Helper.GetLetalisca();
            }
            catch (Exception) { }

            ViewData["letalisca"] = letalisca;
            ViewData["razredi"] = Helpers.Helper.GetRazredi();
            return View("IskanjeLeta");
        }

        public ActionResult IsciLete(FormCollection form)
        {
            DateTime datumodhoda;
            DateTime datumpovratka = new DateTime();
            if (form["povratni"].Equals("false") && form["carterski"].Equals("false") && form["redni"].Equals("false")) return RedirectToAction("Index");

            try
            {
                datumodhoda = DateTime.Parse(form["datumodhoda"]);
                if (!form["povratni"].Equals("false"))
                    datumpovratka = DateTime.Parse(form["datumpovratka"]);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

            LetalisceService.PotovalniRazred raz;
            Enum.TryParse(form["razred"], out raz);
            List<LetalisceService.Let> redni = (!form["redni"].Equals("false")) ? new LetalisceService.Letalec2().izbraniRedniLeti(Int32.Parse(form["idvzlet"]), true, Int32.Parse(form["idpristanek"]), true, datumodhoda, true, raz, true).ToList() : null;
            List<LetalisceService.Let> carterski = (!form["carterski"].Equals("false")) ? new LetalisceService.Letalec2().izbraniCarterskiLeti(Int32.Parse(form["idvzlet"]),true, Int32.Parse(form["idpristanek"]), true, datumodhoda, true).ToList() : null;
            List<LetalisceService.Let> povratni = (!form["povratni"].Equals("false")) ? new LetalisceService.Letalec2().izbraniPovratniLeti(Int32.Parse(form["idvzlet"]), true, Int32.Parse(form["idpristanek"]), true, datumodhoda, true, datumpovratka, true, raz, true).ToList() : null;

            List<LetalisceService.Let> enosmerni = (redni != null) ? redni : null;

            if (enosmerni != null)
            {
                try
                {
                    foreach (LetalisceService.Let l in carterski)
                    {
                        enosmerni.Add(l);
                    }
                }
                catch (Exception) { }
            }
            else
            {
                enosmerni = carterski;
            }

            ViewData["redni"] = enosmerni;
            ViewData["povratni"] = povratni;
            ViewData["razredi"] = Helpers.Helper.GetRazredi();
            ViewData["nazivi"] = Helpers.Helper.GetNaziv();
            ViewData["prtljaga"] = Helpers.Helper.GetPrtljaga();

            return View("MozniLeti");
        }

        [HttpPost]
        public ActionResult KupiKarto(FormCollection form)
        {
            String ime = form["ime"];
            String priimek = form["priimek"];
            String ulica = form["ulica"];
            String kraj = form["kraj"];
            int postna;
            int letid;
            String drzava = form["drzava"];
            String email = form["email"];
            String emso = form["emso"];
            String nazivbanke = form["nazivbanke"];
            String trr = form["TRR"];
            String telefon = form["telefon"];
            DateTime datumtja;
            DateTime datumnazaj;
            double cena;
            String tipkarte = form["tipkarte"];
            Boolean returnflight = true;
            LetalisceService.PotovalniRazred izbranrazred;
            LetalisceService.NazivOsebe izbrannaziv;
            LetalisceService.Prtljaga prtljaga;

            if (ime.Equals("") || priimek.Equals("") || ulica.Equals("") || kraj.Equals("") || drzava.Equals("") || email.Equals("") || emso.Equals("") || nazivbanke.Equals("") || trr.Equals("") || telefon.Equals("") || tipkarte.Equals("")) return RedirectToAction("Index");

            try
            {
                postna = Int32.Parse(form["postna"]);
                cena = Int32.Parse(form["cenainput"]);
                datumtja = DateTime.Parse(form["datumtja"]);
                letid = Int32.Parse(form["letid"]);
                Enum.TryParse<LetalisceService.PotovalniRazred>(form["razred"], out izbranrazred);
                Enum.TryParse<LetalisceService.NazivOsebe>(form["naziv"], out izbrannaziv);
                Enum.TryParse<LetalisceService.Prtljaga>(form["prtljaga"], out prtljaga);
            }
            catch (Exception) {
                return RedirectToAction("Index");
            }

            try
            {
                datumnazaj = DateTime.Parse(form["datumnazaj"]);
            }
            catch (Exception)
            {
                returnflight = false;
            }

            LetalisceService.Oseba oseba = new TehHotel.Gui.Test.LetalisceService.Oseba(){ Ime = ime, Priimek = priimek, Ulica = ulica, Drzava = drzava, Email = email, EMSO = emso, Kraj = kraj, Naziv = izbrannaziv, NazivSpecified = true, Telefon = telefon, PostnaSt = postna, PostnaStSpecified = true, NazivBanke = nazivbanke, TRR = trr};

            LetalisceService.Letalec2 client = new LetalisceService.Letalec2();
            LetalisceService.KartaZaOsebo karta = client.nakupEnosmerneKarte(oseba, letid, true , izbranrazred, true, prtljaga, true, null); 

            return Content("bla");
        }

    }
}
