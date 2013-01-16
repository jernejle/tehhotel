using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{

    [DataContract(Name = "Hotel", Namespace = "http//www.tehhotel.com/")]
    public class Hotel
    {
        public Hotel()
        {

        }

        public Hotel(int id)
        {
            Id = id;
        }

        [DataMember(Name="IdHotel")]
        public int Id { get; set; }

        [DataMember]
        public string Ime { get; set; }

        [DataMember]
        public int Zvezdice { get; set; }

        [DataMember]
        public bool Kuhinja { get; set; }

        [DataMember]
        public bool Bazen { get; set; }

        [DataMember]
        public Naslov Naslov { get; set; }

        [DataMember]
        public List<Soba> Sobe { get; set; }

        [DataMember]
        public List<Dvorana> Dvorane { get; set; }

        [DataMember]
        public List<Parkirisce> Parkirisca { get; set; }

        [DataMember]
        public List<Zaposleni> Osebje { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Ime: {1}, Zvezdice: {2}, Kuhinja: {3}, Bazen: {4}, Naslov: {5}, Sobe: {6}, Dvorane: {7}, Parkirisca: {8}, Osebje: {9}", Id, Ime, Zvezdice, Kuhinja, Bazen, Naslov, Sobe, Dvorane, Parkirisca, Osebje);
        }
    }
}
