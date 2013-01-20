using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TehHotel.Gui.Test.Models
{
    public class BancniRacun
    {
        public string upime { get; set; }
        public string geslo { get; set; }
        public string trr { get; set; }

        public BancniRacun(string upime, string geslo, string trr)
        {
            this.upime = upime;
            this.geslo = geslo;
            this.trr = trr;
        }
    }
}