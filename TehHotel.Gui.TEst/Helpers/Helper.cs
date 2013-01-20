using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TehHotel.Gui.Test.Helpers
{
    public class Helper
    {

        public static List<SelectListItem> GetHoteli()
        {
            List<TehHotel.Gui.Test.HotelService.Hotel> hoteli = new HotelService.HotelService().ListHotel().ToList();
            List<SelectListItem> sl = new List<SelectListItem>();
            foreach (TehHotel.Gui.Test.HotelService.Hotel h in hoteli)
            {
                SelectListItem i = new SelectListItem();
                i.Text = h.Ime;
                i.Value = h.IdHotel.ToString();
                sl.Add(i);
            }
            return sl;
        }

        public static List<SelectListItem> GetLetalisca()
        {
            List<LetalisceService.Letalisce> letalisca = new LetalisceService.Letalec2().vsaLetalisca().ToList();
            List<SelectListItem> sl = new List<SelectListItem>();
            foreach (LetalisceService.Letalisce h in letalisca)
            {
                SelectListItem i = new SelectListItem();
                i.Text = h.Naziv + " - " + h.Kraj + "(" + h.Koda + ")";
                i.Value = h.ID.ToString();
                sl.Add(i);
            }
            return sl;
        }

        public static List<SelectListItem> GetRazredi()
        {
            IEnumerable<LetalisceService.PotovalniRazred> pr = Enum.GetValues(typeof(LetalisceService.PotovalniRazred)).Cast<LetalisceService.PotovalniRazred>();
            List<SelectListItem> pr_li = new List<SelectListItem>();
            foreach (LetalisceService.PotovalniRazred t in pr)
            {
                pr_li.Add(new SelectListItem() { Text = t.ToString(), Value = t.ToString() });
            }
            return pr_li;
        }

        public static List<SelectListItem> GetNaziv()
        {
            IEnumerable<LetalisceService.NazivOsebe> pr = Enum.GetValues(typeof(LetalisceService.NazivOsebe)).Cast<LetalisceService.NazivOsebe>();
            List<SelectListItem> pr_li = new List<SelectListItem>();
            foreach (LetalisceService.NazivOsebe t in pr)
            {
                pr_li.Add(new SelectListItem() { Text = t.ToString(), Value = t.ToString() });
            }
            return pr_li;
        }

        public static List<SelectListItem> GetPrtljaga() {
             IEnumerable<LetalisceService.Prtljaga> pr = Enum.GetValues(typeof(LetalisceService.Prtljaga)).Cast<LetalisceService.Prtljaga>();
            List<SelectListItem> pr_li = new List<SelectListItem>();
            foreach (LetalisceService.Prtljaga t in pr)
            {
                pr_li.Add(new SelectListItem() { Text = t.ToString(), Value = t.ToString() });
            }
            return pr_li;
        }

    }
}