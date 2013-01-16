using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{

    [DataContract(Name = "Soba", Namespace = "http//www.tehhotel.com/")]
    public class Soba
    {

        public Soba()
        {

        }

        public Soba(int id)
        {
            Id = id;
        }

        [DataMember(Name="IdSoba")]
        public int Id { get; set; }

        [DataMember]
        public int Stevilka { get; set; }

        [DataMember]
        public int Nadstropje { get; set; }

        [DataMember]
        public int StPostelj { get; set; }

        [DataMember]
        public Double Cena { get; set; }

        [DataMember]
        public string Valuta { get; set; }

        [DataMember]
        public bool Balkon { get; set; }

        [DataMember]
        public bool Internet { get; set; }

        [DataMember]
        public bool Televizija { get; set; }

        [DataMember]
        public bool Hladilnik { get; set; }

        [DataMember]
        public int HotelId { get; set; }

        public override string ToString()
        {
            return string.Format("Balkon: {0}, Cena: {1}, Hladilnik: {2}, HotelId: {3}, Id: {4}, Internet: {5}, Nadstropje: {6}, Stevilka: {8}, StPostelj: {9}, Televizija: {10}, Valuta: {11}", Balkon, Cena, Hladilnik, HotelId, Id, Internet, Nadstropje, Stevilka, StPostelj, Televizija, Valuta);
        }
    }
}
