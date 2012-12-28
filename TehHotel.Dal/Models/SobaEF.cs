using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Dal.Models
{
    public class SobaEF
    {
        public int Id { get; set; }
        public int Stevilka { get; set; }
        public int StPostelj { get; set; }
        public Double Cena { get; set; }
        public string Valuta { get; set; }
        public bool Balkon { get; set; }
        public bool Internet { get; set; }
        public bool Hladilnik { get; set; }
        public bool Televizija { get; set; }
        public int Nadstropje { get; set; }

        public int? HotelId { get; set; }
        public virtual HotelEF Hotel { get; set; }
    }
}
