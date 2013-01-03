using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.Test.Models;
using TehHotel.Gui.Test.RezervacijaService;

namespace TehHotel.Gui.Test.Controllers
{
    public class RezervacijeController : Controller
    {
        //
        // GET: /Rezervacije/

        public ActionResult Index()
        {
            ViewData["hoteli"] = Helpers.Helper.GetHoteli();

            List<RezervacijaPosebneStoritve> rezervacije_dvorane = (List<RezervacijaPosebneStoritve>) Session["dvorane"];
            List<RezervacijaPosebneStoritve> rezervacije_sob = (List<RezervacijaPosebneStoritve>)Session["sobe"];
            List<RezervacijaPosebneStoritve> rezervacije_parkirisca = (List<RezervacijaPosebneStoritve>)Session["parkirisca"];

            RezervacijaService.RezervacijaService client = new RezervacijaService.RezervacijaService();
            try
            {
                for (int i = 0; i < rezervacije_dvorane.Count(); i++)
                {
                    rezervacije_dvorane[i].dvorana = client.ReadDvorana(rezervacije_dvorane[i].idStoritve, true);
                }
                ViewData["dvorane"] = rezervacije_dvorane;
            }
            catch
            {
                ViewData["dvorane"] = null;
            }
            try
            {
                for (int i = 0; i < rezervacije_sob.Count(); i++)
                {
                    rezervacije_sob[i].soba = client.ReadSoba(rezervacije_sob[i].idStoritve, true);

                }
                ViewData["sobe"] = rezervacije_sob;
            }
            catch
            {}
            try
            {
                for (int i = 0; i < rezervacije_parkirisca.Count(); i++)
                {
                    rezervacije_parkirisca[i].parkirisce = client.ReadParkirisce(rezervacije_parkirisca[i].idStoritve, true);

                }
                ViewData["parkirisca"] = rezervacije_parkirisca;
            }
            catch
            {}

            return View("Izpis");
        }

        public ActionResult Pobrisi()
        {
            Session["dvorane"] = null;
            Session["parkirisca"] = null;
            Session["sobe"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Rezerviraj(RezervacijaModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Izpis");
            }

            List<RezervacijaPosebneStoritve> rezervacije_sob = (List<RezervacijaPosebneStoritve>) Session["sobe"];
            List<RezervacijaPosebneStoritve> rezervacije_dvor = (List<RezervacijaPosebneStoritve>)Session["dvorane"];
            List<RezervacijaPosebneStoritve> rezervacije_park = (List<RezervacijaPosebneStoritve>)Session["parkirisca"];

            List<RezervacijaSobe> rez_sobe = rez_sobe = new List<RezervacijaSobe>();
            List<RezervacijaDvorane> rez_dvorane = null;
            List<RezervacijaParkirisca> rez_parkirisca = null;
            Rezervacije r = new Rezervacije();

            if (rezervacije_sob != null)
            {
                foreach (RezervacijaPosebneStoritve rs in rezervacije_sob)
                {
                    Soba sob = new RezervacijaService.RezervacijaService().ReadSoba(rs.idStoritve, true);
                    sob.CenaSpecified = true;
                    RezervacijaSobe nr = new RezervacijaSobe() { DatumDo = rs.datumDo, DatumOd = rs.datumOd, Hotel = null, Soba = sob, Stranka = null, Hrana = "ne", DatumDoSpecified = true, DatumOdSpecified = true };
                    rez_sobe.Add(nr);
                }
            }

            
            if (rezervacije_dvor != null)
            {
                r = new Rezervacije();
                rez_dvorane = new List<RezervacijaDvorane>();
                foreach (RezervacijaPosebneStoritve rs in rezervacije_dvor)
                {
                    RezervacijaDvorane rd = new RezervacijaDvorane() { DatumDo = rs.datumDo, DatumOd = rs.datumOd, ImePosebneStoritve = "Rezervacija dvorane", Cena = 1000, SteviloLjudi = 100, CenaSpecified = true, DatumDoSpecified = true, DatumOdSpecified = true, Dvorana = new Dvorana() { Id = rs.idStoritve, IdSpecified = true }, SteviloLjudiSpecified = true, Stranka = null };
                    rez_dvorane.Add(rd);
                }
                r.RezervacijeDvorane = rez_dvorane.ToArray();
            }

            if (rezervacije_park != null)
            {
                if (r == null)
                    r = new Rezervacije();

                rez_parkirisca = new List<RezervacijaParkirisca>();
                foreach (RezervacijaPosebneStoritve rs in rezervacije_park)
                {
                    RezervacijaParkirisca rp = new RezervacijaParkirisca() { Cena = 100, DatumDo = rs.datumDo, DatumOd = rs.datumOd, Parkirisce = new Parkirisce() { Id = rs.idStoritve, IdSpecified = true }, ImePosebneStoritve = "Rezervacija parkirisca", Stranka = null, CenaSpecified = true, DatumDoSpecified = true, DatumOdSpecified = true };
                    rez_parkirisca.Add(rp);
                }
                r.RezervacijeParkirisca = rez_parkirisca.ToArray();
            }
            
            RezervacijaService.RezervacijaService client = new RezervacijaService.RezervacijaService();
            StrankaService.StrankaService cl = new StrankaService.StrankaService();
            TehHotel.Gui.Test.StrankaService.Stranka strObj = cl.IsciStranka(model.identifikacijatip, model.identifikacijavrednost);

            int strankaId = 0;
            try
            {
                strankaId = strObj.Id;
            }
            catch
            {
                int res;
                bool bReturn;
                TehHotel.Gui.Test.StrankaService.Stranka serv_stranka = new TehHotel.Gui.Test.StrankaService.Stranka() { DatumRojstva = model.datumroj, Ime = model.ime, Priimek = model.priimek, Identifikacija = new TehHotel.Gui.Test.StrankaService.Identifikacija() { Tip = model.identifikacijatip, Vrednost = model.identifikacijavrednost }, Naslov = new TehHotel.Gui.Test.StrankaService.Naslov() { Drzava = model.drzava, Kraj = model.kraj, PostnaStevilka = model.postna, Ulica = model.ulica, PostnaStevilkaSpecified = true }, DatumRojstvaSpecified = true };
                cl.CreateStrankaReturnId(serv_stranka, out res, out bReturn);
                if (!bReturn) return Content("problem!");
                strankaId = res;
            }

            client.CreateRezervacija(strankaId, true, model.hotelid,true, rez_sobe.ToArray(), r);
            this.ModelState.Clear();
            return RedirectToAction("Index", "Stranka");
        }

    }
}