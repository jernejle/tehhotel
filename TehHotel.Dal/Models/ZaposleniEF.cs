using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Dal.Models
{
    public class ZaposleniEF
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Vloga { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public string Spol { get; set; }
        public DateTime? DatumRojstva { get; set; }
        public string Izobrazba { get; set; }
        public DateTime? DatumZaposlitve { get; set; }
        public int? Telefon { get; set; }

        public int? NaslovId { get; set; }
        public virtual NaslovEF Naslov { get; set; }

        public int? IdentifikacijaId { get; set; }
        public virtual IdentifikacijaEF Identifikacija { get; set; }

        public int? HotelId { get; set; }
        public virtual HotelEF Hotel { get; set; }
    }
}
