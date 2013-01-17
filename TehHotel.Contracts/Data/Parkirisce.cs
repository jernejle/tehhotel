using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{
    [DataContract(Name = "Parkirisce", Namespace = "http//www.tehhotel.com/")]
    public class Parkirisce
    {
        [DataMember(Name="IdParkirisce")]
        public int Id { get; set; }

        [DataMember]
        public string Stevilka { get; set; }

        [DataMember]
        public bool Pokrito { get; set; }

        [DataMember]
        public int HotelId { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Stevilka: {1}, Pokrito: {2}, HotelId: {3}", Id, Stevilka, Pokrito, HotelId);
        }
    }
}
