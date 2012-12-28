using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TehHotel.Contracts.Data;

namespace TehHotel.Dal.Models
{
    public class RezervacijaSobeEF
    {
        public int Id { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }

        public int? HotelId { get; set; }
        public HotelEF Hotel { get; set; }

        public int? StrankaId { get; set; }
        public StrankaEF Stranka { get; set; }

        public int? SobaId { get; set; }
        public SobaEF Soba { get; set; }

        public string Hrana { get; set; }
    }
}
