using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TehHotel.Gui.Test.StrankaService;

namespace TehHotel.Gui.Test.Controllers
{
    public class StrankaController : Controller
    {
        //
        // GET: /Stranka/

        public ActionResult Index()
        {
            List<Stranka> stranke = new StrankaService.StrankaService().ListStranka().ToList();
            ViewData["stranke"] = stranke;
            return View("Seznam");
        }

    }
}
