using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{
    [DataContract(Name = "Rezervacije", Namespace = "http//www.tehhotel.com/")]
    public class PosebneRezervacije
    {
        [DataMember]
        public List<RezervacijaDvorane> RezervacijeDvorane { get; set; }

        [DataMember]
        public List<RezervacijaParkirisca> RezervacijeParkirisca { get; set; }

        public override string ToString()
        {
            return string.Format("RezervacijeDvorane: {0}, RezervacijeParkirisca: {1}", RezervacijeDvorane, RezervacijeParkirisca);
        }
    }
}
