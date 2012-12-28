using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Dal.Models
{
    public class RacunEF
    {
        public int Id { get; set; }
        public int StevilkaRacuna { get; set; }
        public DateTime DatumRacuna { get; set; }
        public String Valuta { get; set; }
        public decimal SkupnaCena { get; set; }
        public Boolean Placano { get; set; }

        public int StrankaId { get; set; }
        public virtual StrankaEF Stranka { get; set; }

        public int HotelId { get; set; }
        public virtual HotelEF Hotel { get; set; }

        public virtual ICollection<RezervacijaSobeEF> RezervacijeSob { get; set; }
        public virtual ICollection<RezervacijaDvoraneEF> RezervacijeDvorane { get; set; }
        public virtual ICollection<RezervacijaParkiriscaEF> RezervacijeParkirisca { get; set; }
    }
}
