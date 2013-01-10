using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TehHotel.TestClient.HotelServiceReference;
using TehHotel.TestClient.RezervacijaServiceRef;

namespace TehHotel.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {

            HotelServiceReference.HotelServiceClient client = new HotelServiceClient();
            //RemoteHotelService.HotelServiceClient client = new RemoteHotelService.HotelServiceClient();
            Console.WriteLine(client.ListHotel().Count());
            Console.WriteLine("DONE");
            Console.ReadLine();
            //Console.WriteLine(client.ListZaposleniByHotel(0).Count());
            //Console.WriteLine("DONE");
            //Console.ReadLine();

            /*
            RezervacijaServiceClient c = new RezervacijaServiceClient();
            List<RezervacijaSobe> rezsobe = new List<RezervacijaSobe>();
            RezervacijaSobe rez = new RezervacijaSobe(){DatumDo = DateTime.Now, DatumOd = DateTime.Now, Hotel = new TehHotel.TestClient.RezervacijaServiceRef.Hotel(){Id = 1}, Stranka = new Stranka(){Id=8}, Soba = new TehHotel.TestClient.RezervacijaServiceRef.Soba(){ Id = 16}};
            List<RezervacijaDvorane> rezdvorane = new List<RezervacijaDvorane>();
            RezervacijaDvorane rd = new RezervacijaDvorane() { DatumDo = DateTime.Now, DatumOd = DateTime.Now, Dvorana = new TehHotel.TestClient.RezervacijaServiceRef.Dvorana() { Id = 203 }, Stranka = new Stranka() { Id = 8 }, ImePosebneStoritve = "Rezervacija dvorane", SteviloLjudi = 500 };
            List<RezervacijaParkirisca> rpark = new List<RezervacijaParkirisca>();
            RezervacijaParkirisca rezpark = new RezervacijaParkirisca() { DatumDo = DateTime.Now, DatumOd = DateTime.Now, ImePosebneStoritve = "Rezervacija park", Parkirisce = new TehHotel.TestClient.RezervacijaServiceRef.Parkirisce() { Id = 294 }, Stranka = new Stranka() { Id = 8 }, Cena = 22 };

            rezdvorane.Add(rd);
            rezsobe.Add(rez);
            rpark.Add(rezpark);
            Rezervacije zr = new Rezervacije();
            zr.RezervacijeDvorane = rezdvorane.ToArray();
            zr.RezervacijeParkirisca = rpark.ToArray();

            c.CreateRezervacija(54, rezsobe.ToArray(), zr);
             * */


            RezervacijaServiceClient c = new RezervacijaServiceClient();
            
            /*
            Rezervacije r = new Rezervacije();
            RezervacijaDvorane rd = new RezervacijaDvorane(){ DatumOd = DateTime.Now, DatumDo = DateTime.Now.AddDays(3), SteviloLjudi = 50, Stranka = new Stranka(){ Id = 56}, Cena = 300, Dvorana = new TehHotel.TestClient.RezervacijaServiceRef.Dvorana(){Id = 1}, ImePosebneStoritve = "rezervacija dvorane"};
            RezervacijaParkirisca rp = new RezervacijaParkirisca(){ DatumOd = DateTime.Now, DatumDo = DateTime.Now.AddDays(3), Stranka = new Stranka(){ Id = 56}, ImePosebneStoritve = "rez park", Cena = 33, Parkirisce = new TehHotel.TestClient.RezervacijaServiceRef.Parkirisce(){ Id = 295}};
            List<RezervacijaDvorane> r_list = new List<RezervacijaDvorane>();
            List<RezervacijaParkirisca> park_list = new List<RezervacijaParkirisca>();
            r_list.Add(rd);
            park_list.Add(rp);
            r.RezervacijeDvorane = r_list.ToArray();
            r.RezervacijeParkirisca = park_list.ToArray();
            //c.CreateRezervacija(56, new List<RezervacijaSobe>().ToArray(), r);

            List<TehHotel.TestClient.RezervacijaServiceRef.Dvorana> dvorane = c.ListMozneRezervacijeDvorane(1, DateTime.Now, DateTime.Now.AddDays(2)).ToList();
            List<TehHotel.TestClient.RezervacijaServiceRef.Parkirisce> parkirisca = c.ListMozneRezervacijeParkirisca(1, DateTime.Now, DateTime.Now.AddDays(2)).ToList();

            Console.WriteLine("bla");
             */
        }
    }
}
