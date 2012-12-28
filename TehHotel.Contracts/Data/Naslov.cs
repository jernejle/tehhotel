using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{
    [DataContract(Name = "Naslov", Namespace = "http//www.tehhotel.com/")]
    public class Naslov
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Drzava { get; set; }

        [DataMember]
        public int PostnaStevilka { get; set; }

        [DataMember]
        public string Kraj { get; set; }

        [DataMember]
        public string Ulica { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Drzava: {1}, PostnaStevilka: {2}, Kraj: {3}, Ulica: {4}", Id, Drzava, PostnaStevilka, Kraj, Ulica);
        }
    }
}
