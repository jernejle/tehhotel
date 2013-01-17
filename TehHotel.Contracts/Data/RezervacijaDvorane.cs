using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{
    [DataContract(Name = "RezervacijaDvorane", Namespace = "http//www.tehhotel.com/", IsReference = true)]
    public class RezervacijaDvorane
    {
        [DataMember(Name="IdRezervacijaDvorane")]
        public int Id { get; set; }

        [DataMember]
        public int SteviloLjudi { get; set; }

        [DataMember]
        public Dvorana Dvorana { get; set; }

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
            return string.Format("Id: {0}, SteviloLjudi: {1}, Dvorana: {2}, Stranka: {3}, ImePosebneStoritve: {4}, Cena: {5}, DatumOd: {6}, DatumDo: {7}", Id, SteviloLjudi, Dvorana, Stranka, ImePosebneStoritve, Cena, DatumOd, DatumDo);
        }
    }
}
