using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Dal.Models
{
    public class ParkirisceEF
    {
        public int Id { get; set; }
        public string Stevilka { get; set; }
        public bool Pokrito { get; set; }

        public int? HotelId { get; set; }
        public virtual HotelEF Hotel { get; set; }
    }
}
