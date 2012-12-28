using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TehHotel.Contracts.Data;

namespace TehHotel.Dal.Models
{
    public class StrankaEF
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public DateTime DatumRojstva { get; set; }

        public int? NaslovId { get; set; }
        public NaslovEF Naslov { get; set; }

        public int? IdentifikacijaId { get; set; }
        public IdentifikacijaEF Identifikacija { get; set; }
    }
}
