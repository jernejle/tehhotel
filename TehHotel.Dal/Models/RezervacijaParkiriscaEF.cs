using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Dal.Models
{
    public class RezervacijaParkiriscaEF
    {
        public int Id { get; set; }

        public int ParkirisceId { get; set; }
        public virtual ParkirisceEF Parkirisce { get; set; }

        public int StrankaId { get; set; }
        public virtual StrankaEF Stranka { get; set; }

        public String ImePosebneStoritve
        {
            get;
            set;
        }

        public decimal Cena
        {
            get;
            set;
        }

        public DateTime DatumOd
        {
            get;
            set;
        }

        public DateTime DatumDo
        {
            get;
            set;
        }
    }
}
