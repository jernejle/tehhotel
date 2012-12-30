using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.Test.Models;

namespace TehHotel.Gui.Test.Controllers
{
    public class RezervacijeController : Controller
    {
        //
        // GET: /Rezervacije/

        public ActionResult Index()
        {
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

    }
}
