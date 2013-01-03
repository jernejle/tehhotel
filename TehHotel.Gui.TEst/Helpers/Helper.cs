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
                i.Value = h.Id.ToString();
                sl.Add(i);
            }
            return sl;
        }

    }
}