using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TehHotel.Contracts.Data
{
    [DataContract(Name = "Zaposleni", Namespace = "http//www.tehhotel.com/")]
    public class Zaposleni
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Vloga { get; set; }

        [DataMember]
        public string Ime { get; set; }

        [DataMember]
        public string Priimek { get; set; }

        [DataMember]
        public string Spol { get; set; }

        [DataMember]
        public DateTime? DatumRojstva { get; set; }

        [DataMember]
        public string Izobrazba { get; set; }

        [DataMember]
        public DateTime? DatumZaposlitve { get; set; }

        [DataMember]
        public int Telefon { get; set; }

        [DataMember]
        public Naslov Naslov { get; set; }

        [DataMember]
        public Identifikacija Identifikacija { get; set; }

        [DataMember]
        public int? HotelId { get; set; }

        public override string ToString()
        {
            return string.Format("Id: {0}, Username: {1}, Password: {2}, Email: {3}, Vloga: {4}, Ime: {5}, Priimek: {6}, Spol: {7}, DatumRojstva: {8}, Izobrazba: {9}, DatumZaposlitve: {10}, Telefon: {11}, Naslov: {12}, Identifikacija: {13}, HotelId: {14}", Id, Username, Password, Email, Vloga, Ime, Priimek, Spol, DatumRojstva, Izobrazba, DatumZaposlitve, Telefon, Naslov, Identifikacija, HotelId);
        }
    }
}
