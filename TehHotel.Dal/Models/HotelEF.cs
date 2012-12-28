using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Dal.Models
{
    public class HotelEF
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public int Zvezdice { get; set; }
        public bool Kuhinja { get; set; }
        public bool Bazen { get; set; }

        
        public int? NaslovId { get; set; }
        public virtual NaslovEF Naslov { get; set; }

        public virtual List<DvoranaEF> Dvorane { get; set; }

        public virtual List<ZaposleniEF> Osebje { get; set; }

        public virtual List<ParkirisceEF> Parkirisca { get; set; }

        public virtual List<SobaEF> Sobe { get; set; }
    }
}
