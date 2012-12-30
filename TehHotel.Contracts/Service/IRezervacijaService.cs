using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TehHotel.Contracts.Data;

namespace TehHotel.Contracts.Service
{
    [ServiceContract(Name = "RezervacijaService", Namespace = "http//www.tehhotel.com/")]
    public interface IRezervacijaService
    {
        [OperationContract]
        Racun CreateRezervacija(int idStranka, List<RezervacijaSobe> rezervacijeSobe, PosebneRezervacije posebneRezervacije);

        [OperationContract]
        bool DeleteRacun(int id);

        [OperationContract]
        bool DeleteRezervacijaSobe(int id);

        [OperationContract]
        bool DeleteRezervacijaDvorane(int id);

        [OperationContract]
        bool DeleteRezervacijaParkirisca(int id);

        [OperationContract]
        List<Racun> ListRacun(int idStranka);

        [OperationContract]
        List<Racun> ListRacunNeplacani(int idStranka);

        [OperationContract]
        bool PlacajRacun(int id);

        [OperationContract]
        List<Soba> ListMozneRezervacijeSobe(int idHotel, DateTime datumOd, DateTime datumDo, FilterOptionsSoba fos);

        [OperationContract]
        List<Dvorana> ListMozneRezervacijeDvorane(int idHotel, DateTime datumOd, DateTime datumDo);

        [OperationContract]
        List<Parkirisce> ListMozneRezervacijeParkirisca(int idHotel, DateTime datumOd, DateTime datumDo);

        [OperationContract]
        Racun ReadRacun(int Racunid);

        [OperationContract]
        Soba ReadSoba(int SobaId);

        [OperationContract]
        Dvorana ReadDvorana(int DvoranaId);

        [OperationContract]
        Parkirisce ReadParkirisce(int ParkirisceId);

    }
}
