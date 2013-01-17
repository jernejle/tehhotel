using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{
    [DataContract(Name = "Racun", Namespace = "http//www.tehhotel.com/", IsReference = true)]
    public class Racun
    {
        [DataMember(Name="IdRacun")]
        public int Id { get; set; }

        [DataMember]
        public int StevilkaRacuna { get; set; }

        [DataMember]
        public DateTime DatumRacuna { get; set; }

        [DataMember]
        public String Valuta { get; set; }

        [DataMember]
        public decimal SkupnaCena { get; set; }

        [DataMember]
        public Boolean Placano { get; set; }
        
        [DataMember]
        public Stranka Stranka { get; set; }

        [DataMember]
        public int HotelId { get; set; }

        [DataMember]
        public List<RezervacijaSobe> RezervacijeSob { get; set; }

        [DataMember]
        public List<RezervacijaDvorane> RezervacijeDvorane { get; set; }

        [DataMember]
        public List<RezervacijaParkirisca> RezervacijeParkirisca { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, StevilkaRacuna: {1}, DatumRacuna: {2}, Valuta: {3}, SkupnaCena: {4}, Placano: {5}, Stranka: {6}, HotelId: {7}, RezervacijeSob: {8}, RezervacijeDvorane: {9}, RezervacijeParkirisca: {10}", Id, StevilkaRacuna, DatumRacuna, Valuta, SkupnaCena, Placano, Stranka, HotelId, RezervacijeSob, RezervacijeDvorane, RezervacijeParkirisca);
        }
    }
}
