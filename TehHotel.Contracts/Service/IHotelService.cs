using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TehHotel.Contracts.Data;

namespace TehHotel.Contracts.Service
{
    [ServiceContract(Name = "HotelService", Namespace = "http//www.tehhotel.com/")]
    public interface IHotelService
    {
        [OperationContract]
        bool CreateHotel(Hotel h);

        [OperationContract]
        Hotel ReadHotel(int id);

        [OperationContract]
        bool UpdateHotel(Hotel h);

        [OperationContract]
        bool DeleteHotel(int id);

        [OperationContract]
        List<Hotel> ListHotel();

        [OperationContract]
        List<Hotel> ListHotelByKraj(string kraj);

        [OperationContract]
        List<Hotel> ListHotelByDrzava(string drzava);

        [OperationContract]
        bool AddSoba(int hotelId, Soba s);

        [OperationContract]
        bool RemoveSoba(int hotelId, int sobaId);

        [OperationContract]
        bool AddDvorana(int hotelId, Dvorana d);

        [OperationContract]
        bool RemoveDvorana(int hotelId, int dvoranaId);

        [OperationContract]
        bool AddParkirisce(int hotelId, Parkirisce p);

        [OperationContract]
        bool RemoveParkirisce(int hotelId, int parkirisceId);

        [OperationContract]
        bool CreateZaposleni(Zaposleni z);

        [OperationContract]
        Zaposleni ReadZaposleni(int id);

        [OperationContract]
        bool UpdateZaposleni(Zaposleni z);

        [OperationContract]
        bool DeleteZaposleni(int id);

        [OperationContract]
        List<Zaposleni> ListZaposleni();

        [OperationContract]
        List<Zaposleni> ListZaposleniByHotel(int hotelId);
    }
}
