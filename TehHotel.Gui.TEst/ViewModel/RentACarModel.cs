using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TehHotel.Gui.Test.Models
{
    public class RentACarModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int IdVozilo { get; set; }
        public int IdStranka { get; set; }

        public List<RentACarVozilaService.Vozilo> VozilaFull { get; set; }
        public List<object> Stranke { get; set; }

        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }

        public RentACarModel()
        {
            this.DatumOd = DateTime.Now;
            this.DatumDo = DateTime.Now;

            StrankaService.StrankaService clientStranka = new StrankaService.StrankaService();
            this.Stranke = new List<object>();
            foreach (StrankaService.Stranka s in clientStranka.ListStranka().ToList())
            {
                this.Stranke.Add(new
                {
                    Id = s.IdStranka,
                    Ime = s.Ime + " " + s.Priimek + " " + s.Identifikacija.Tip + ": " + s.Identifikacija.Vrednost
                });
            }

            RentACarVozilaService.Vozila clientVozila = new RentACarVozilaService.Vozila();
            VozilaFull = clientVozila.pregledRazpolozljivihVozil().ToList();
        }

    }
}