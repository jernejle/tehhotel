using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{
    [DataContract]
    public class RezervacijaSobe
    {
        public RezervacijaSobe()
        {

        }

        public RezervacijaSobe(DateTime DatumOd, DateTime DatumDo, int idHotel, int idStranka, int idSoba, string Hrana)
        {
            this.DatumOd = DatumOd;
            this.DatumDo = DatumDo;
            this.Hotel = new Hotel(idHotel);
            this.Stranka = new Stranka(idStranka);
            this.Soba = new Soba(idSoba);
        }

        [DataMember(Name="RezervacijaSobe")]
        public int Id { get; set; }

        [DataMember]
        public DateTime DatumOd { get; set; }

        [DataMember]
        public DateTime DatumDo { get; set; }

        [DataMember]
        public Hotel Hotel { get; set; }
        
        [DataMember]
        public Stranka Stranka { get; set; }
       
        [DataMember]
        public Soba Soba { get; set; }

        [DataMember]
        public string Hrana { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, DatumOd: {1}, DatumDo: {2}, Hotel: {3}, Stranka: {4}, Soba: {5}, Hrana: {6}", Id, DatumOd, DatumDo, Hotel, Stranka, Soba, Hrana);
        }
    }
}
