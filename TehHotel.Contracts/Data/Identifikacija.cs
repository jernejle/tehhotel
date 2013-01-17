using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{
    [DataContract(Name = "Identifikacija", Namespace = "http//www.tehhotel.com/")]
    public class Identifikacija
    {
        [DataMember(Name="IdIdentifikacija")]
        public int Id { get; set; }

        [DataMember]
        public string Tip { get; set; }

        [DataMember]
        public string Vrednost { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Tip: {1}, Vrednost: {2}", Id, Tip, Vrednost);
        }
    }
}
