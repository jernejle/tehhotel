using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Dal.Models
{
    public class DvoranaEF
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public Double Povrsina { get; set; }
        public int StLjudi { get; set; }

        public int? HotelId { get; set; }
        public virtual HotelEF Hotel { get; set; }
    }
}
