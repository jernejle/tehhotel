using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{
    [DataContract(Name = "Stranka", Namespace = "http//www.tehhotel.com/", IsReference = true)]
    public class Stranka
    {
        public Stranka()
        {
            
        }

        public Stranka(int id)
        {
            Id = id;
        }

        [DataMember(Name="IdStranka")]
        public int Id { get; set; }

        [DataMember]
        public string Ime { get; set; }

        [DataMember]
        public string Priimek { get; set; }

        [DataMember]
        public DateTime DatumRojstva { get; set; }

        [DataMember]
        public Naslov Naslov { get; set; }

        [DataMember]
        public Identifikacija Identifikacija { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Ime: {1}, Priimek: {2}, DatumRojstva: {3}, Naslov: {4}, Identifikacija: {5}", Id, Ime, Priimek, DatumRojstva, Naslov, Identifikacija);
        }
    }
}
