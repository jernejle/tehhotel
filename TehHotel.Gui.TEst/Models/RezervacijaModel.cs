using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TehHotel.Gui.Test.Models
{
    public class RezervacijaModel
    {
        public String ime { get; set; }
        public String priimek { get; set; }
        public DateTime datumroj { get; set; }
        public String drzava { get; set; }
        public String kraj { get; set; }
        public String ulica { get; set; }
        public int postna { get; set; }
        public int hotelid { get; set; }
        public String identifikacijatip { get; set; }
        public String identifikacijavrednost { get; set; }

    }
}