using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{
    [DataContract(Name = "FilterOptionsSoba", Namespace = "http//www.tehhotel.com/", IsReference = true)]
    public class FilterOptionsSoba
    {
        [DataMember]
        public int? Nadstropje { get; set; }

        [DataMember]
        public int? StPostelj { get; set; }

        [DataMember]
        public bool? Balkon { get; set; }

        [DataMember]
        public bool? Internet { get; set; }

        [DataMember]
        public bool? Televizija { get; set; }

        [DataMember]
        public bool? Hladilnik { get; set; }

        [DataMember]
        public int? Zvezdice { get; set; }
    }
}
