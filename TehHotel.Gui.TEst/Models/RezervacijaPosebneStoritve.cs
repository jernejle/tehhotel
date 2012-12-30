using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TehHotel.Gui.Test.RezervacijaService;

namespace TehHotel.Gui.Test.Models
{
    public class RezervacijaPosebneStoritve
    {
        public int idStoritve { get; set; }
        public DateTime datumOd { get; set; }
        public DateTime datumDo { get; set; }

        public Soba soba { get; set; }
        public Parkirisce parkirisce { get; set; }
        public Dvorana dvorana { get; set; }
    }
}