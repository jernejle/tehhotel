using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TehHotel.Gui.Test.RezervacijaService;

namespace TehHotel.Gui.Test.Objects
{
    public class RezervacijaSobeObj
    {
        public int HotelId { get; set; }
        public FilterOptionsSoba Fos { get; set; }
        public DateTime DatumOd{ get; set; }
        public DateTime DatumDo { get; set; }
    }
}