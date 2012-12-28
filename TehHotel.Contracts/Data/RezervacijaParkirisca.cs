using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{
    [DataContract(Name = "RezervacijaParkirisca", Namespace = "http//www.tehhotel.com/", IsReference = true)]
    public class RezervacijaParkirisca
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Parkirisce Parkirisce { get; set; }

        [DataMember]
        public Stranka Stranka { get; set; }

        [DataMember]
        public String ImePosebneStoritve { get; set; }

        [DataMember]
        public decimal Cena { get; set; }

        [DataMember]
        public DateTime DatumOd { get; set; }

        [DataMember]
        public DateTime DatumDo { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Parkirisce: {1}, Stranka: {2}, ImePosebneStoritve: {3}, Cena: {4}, DatumOd: {5}, DatumDo: {6}", Id, Parkirisce, Stranka, ImePosebneStoritve, Cena, DatumOd, DatumDo);
        }
    }
}
