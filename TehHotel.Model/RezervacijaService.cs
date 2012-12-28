using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TehHotel.Contracts.Service;
using TehHotel.Contracts.Data;
using TehHotel.Dal.Models.Dao;

namespace TehHotel.Model
{
    class RezervacijaService : IRezervacijaService
    {
        RezervacijaSobeEFDao rsdao = new RezervacijaSobeEFDao();
        RacunEFDao racdao = new RacunEFDao();
        StrankaEFDao strankadao = new StrankaEFDao();
        SobaEFDao sobadao = new SobaEFDao();
        HotelEFDao hoteldao = new HotelEFDao();

        public Racun CreateRezervacija(int idStranka, List<RezervacijaSobe> rezervacijeSobe, PosebneRezervacije posebneRezervacije)
        {
            if (idStranka == 0) return null;
            Stranka s = new Stranka();
            s.Id = idStranka;
            if (s == null) return null;

            Random rnd = new Random();
            int stev = rnd.Next(1000, 98989);
            
            if (rezervacijeSobe == null)
                rezervacijeSobe = new List<RezervacijaSobe>();

            if (rezervacijeSobe.Count() == 0 && posebneRezervacije == null) return null;


            double cena = 0.0;
            for(int i = 0; i < rezervacijeSobe.Count; i++) {
                cena += rezervacijeSobe.ElementAt(i).Soba.Cena;
            }

            if (posebneRezervacije != null)
            {
                if (posebneRezervacije.RezervacijeDvorane != null)
                {
                    foreach (RezervacijaDvorane rd in posebneRezervacije.RezervacijeDvorane)
                    {
                        cena += Double.Parse(rd.Cena.ToString());
                    }
                }
                if (posebneRezervacije.RezervacijeParkirisca != null)
                {
                    foreach (RezervacijaParkirisca rp in posebneRezervacije.RezervacijeParkirisca)
                    {
                        cena += Double.Parse(rp.Cena.ToString());
                    }
                }
            }
            else
            {
                posebneRezervacije.RezervacijeParkirisca = new List<RezervacijaParkirisca>();
                posebneRezervacije.RezervacijeDvorane = new List<RezervacijaDvorane>();
            }


            Racun rac = new Racun() { DatumRacuna = DateTime.Now, Placano = false, StevilkaRacuna = stev, Stranka = s, RezervacijeSob = rezervacijeSobe, RezervacijeDvorane = posebneRezervacije.RezervacijeDvorane, RezervacijeParkirisca = posebneRezervacije.RezervacijeParkirisca, SkupnaCena = (decimal) cena, Valuta="EUR", HotelId = 1};
            bool ok = racdao.Create(rac);
            if (!ok)
            {
                rac = null;
            }
            return rac;
        }

        public bool DeleteRacun(int id)
        {
            return racdao.Delete(id);
        }

        public bool DeleteRezervacijaSobe(int id)
        {
            return rsdao.Delete(id);
        }

        public bool DeleteRezervacijaDvorane(int id)
        {
            return new RezervacijaDvoraneEFDao().Delete(id);
        }

        public bool DeleteRezervacijaParkirisca(int id)
        {
            return new RezervacijaParkirisceEFDao().Delete(id);
        }

        public List<Racun> ListRacun(int idStranka)
        {
            return racdao.ReadAllByStranka(idStranka);
        }

        public List<Racun> ListRacunNeplacani(int idStranka)
        {
            return racdao.readNeplacaniRacuniStranke(idStranka);
        }

        public bool PlacajRacun(int id)
        {
            throw new NotImplementedException(); // TO-DO
        }

        public List<Soba> ListMozneRezervacijeSobe(int idHotel, DateTime datumOd, DateTime datumDo, FilterOptionsSoba fos)
        {
            return rsdao.MozneRezervacijeSobe(idHotel, datumOd, datumDo, fos);
        }

        public List<Dvorana> ListMozneRezervacijeDvorane(int idHotel, DateTime datumOd, DateTime datumDo)
        {
            return new RezervacijaDvoraneEFDao().mozneRezervacijeDvorane(idHotel, datumOd, datumOd).ToList();
        }

        public List<Parkirisce> ListMozneRezervacijeParkirisca(int idHotel, DateTime datumOd, DateTime datumDo)
        {
            return new RezervacijaParkirisceEFDao().mozneRezervacijeParkirisca(idHotel, datumOd, datumDo);
        }
    }
}
