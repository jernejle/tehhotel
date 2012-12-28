using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{
    [DataContract(Name = "Dvorana", Namespace = "http//www.tehhotel.com/", IsReference = true)]
    public class Dvorana
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Ime { get; set; }

        [DataMember]
        public Double Povrsina { get; set; }

        [DataMember]
        public int StLjudi { get; set; }

        [DataMember]
        public int HotelId { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Ime: {1}, Povrsina: {2}, StLjudi: {3}, HotelId: {4}", Id, Ime, Povrsina, StLjudi, HotelId);
        }
    }
}
