using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TehHotel.Contracts.Data;

namespace TehHotel.Dal.Models.Dao
{
    public class RacunEFDao : IDao<Racun>
    {
        public TehHotelContext db;

        public RacunEFDao()
        {
             db = new TehHotelContext();

            Mapper.CreateMap<RacunEF, Racun>();
            Mapper.CreateMap<Racun, RacunEF>();

            Mapper.CreateMap<DvoranaEF, Dvorana>();
            Mapper.CreateMap<Dvorana, DvoranaEF>();

            Mapper.CreateMap<StrankaEF, Stranka>();
            Mapper.CreateMap<Stranka, StrankaEF>();

            Mapper.CreateMap<IdentifikacijaEF, Identifikacija>();
            Mapper.CreateMap<Identifikacija, IdentifikacijaEF>();

            Mapper.CreateMap<RezervacijaParkiriscaEF, RezervacijaParkirisca>();
            Mapper.CreateMap<RezervacijaParkirisca, RezervacijaParkiriscaEF>();

            Mapper.CreateMap<ParkirisceEF, Parkirisce>();
            Mapper.CreateMap<Parkirisce, ParkirisceEF>();

            Mapper.CreateMap<RezervacijaDvoraneEF, RezervacijaDvorane>();
            Mapper.CreateMap<RezervacijaDvorane, RezervacijaDvoraneEF>();

            Mapper.CreateMap<DvoranaEF, Dvorana>();
            Mapper.CreateMap<Dvorana, DvoranaEF>();

            Mapper.CreateMap<RezervacijaSobeEF, RezervacijaSobe>();
            Mapper.CreateMap<RezervacijaSobe, RezervacijaSobeEF>();

            Mapper.CreateMap<HotelEF, Hotel>();
            Mapper.CreateMap<Hotel, HotelEF>();

            Mapper.CreateMap<SobaEF, Soba>();
            Mapper.CreateMap<Soba, SobaEF>();
        }


        public bool Create(Racun entity)
        {
                if (entity != null)
                {
                    RacunEF rac = Mapper.Map<Racun, RacunEF>(entity);
                    HotelEF h = new HotelEF() { Id = entity.HotelId };
                    StrankaEF s = new StrankaEF() { Id = entity.Stranka.Id};
                    db.Stranke.Attach(s);
                    db.Hoteli.Attach(h);

                    rac.Hotel = h;
                    rac.Stranka = s;

                    if (entity.RezervacijeSob != null)
                    {
                        int sobaid;
                        for (int i = 0; i < entity.RezervacijeSob.Count; i++)
                        {
                            sobaid = entity.RezervacijeSob.ElementAt(i).Soba.Id;
                            rac.RezervacijeSob.ElementAt(i).Hotel = h;
                            rac.RezervacijeSob.ElementAt(i).Stranka = s;
                            rac.RezervacijeSob.ElementAt(i).Soba = db.Sobe.SingleOrDefault(x => x.Id ==  sobaid);
                        }
                    }

                    if (entity.RezervacijeDvorane != null)
                    {
                        int dvoranaId;
                        for (int i = 0; i < entity.RezervacijeDvorane.Count; i++)
                        {
                            dvoranaId = entity.RezervacijeDvorane.ElementAt(i).Dvorana.Id;
                            rac.RezervacijeDvorane.ElementAt(i).Stranka = s;
                            rac.RezervacijeDvorane.ElementAt(i).Dvorana = db.Dvorane.SingleOrDefault(x => x.Id == dvoranaId);
                        }
                    }

                    if (entity.RezervacijeParkirisca != null)
                    {
                        int parkId;
                        for (int i = 0; i < entity.RezervacijeParkirisca.Count; i++)
                        {
                            parkId = entity.RezervacijeParkirisca.ElementAt(i).Parkirisce.Id;
                            rac.RezervacijeParkirisca.ElementAt(i).Parkirisce = db.Parkirisca.SingleOrDefault(x => x.Id == parkId);
                            rac.RezervacijeParkirisca.ElementAt(i).Stranka = s;
                        }
                    }
                    
                    db.Racuni.Add(rac);
                    db.SaveChanges();
                    return true;
                }
                return false;
        }

        public Racun Read(int id)
        {
                RacunEF racunef = db.Racuni.Include("Stranka").Include("RezervacijeSob").Include("RezervacijeSob.Soba").Include("RezervacijeDvorane").Include("RezervacijeParkirisca").SingleOrDefault(x => x.Id == id);
                Racun rp = (racunef != null) ? Mapper.Map<RacunEF, Racun>(racunef) : null;
                return rp;
        }

        public Racun ReadByStranka(int id)
        {
                RacunEF racunef = db.Racuni.Include("Stranka").Include("RezervacijeSob").Include("RezervacijeDvorane").Include("RezervacijeParkirisca").Where(w => w.Placano == false).Where(q => q.Stranka.Id == id).OrderByDescending(x => x.Id).FirstOrDefault();
                Racun rp = (racunef != null) ? Mapper.Map<RacunEF, Racun>(racunef) : null;
                return rp;
        }

        public List<Racun> ReadAllByStranka(int id)
        {
                List<RacunEF> racuni_ef = db.Racuni.Include("Stranka").Include("RezervacijeSob").Include("RezervacijeDvorane").Include("RezervacijeParkirisca").Where(q => q.Stranka.Id == id).ToList();
                List<Racun> racuni = (racuni_ef != null ) ? Mapper.Map<List<RacunEF>, List<Racun>>(racuni_ef) : null;
                return racuni;
        }

        public bool Update(Racun entity)
        {
                RacunEF rac_ef = Mapper.Map<Racun, RacunEF>(entity);
                db.Racuni.Attach(rac_ef);
                db.Entry(rac_ef).State = EntityState.Modified;
                db.SaveChanges();
                return true;
        }

        public bool Delete(int id)
        {
            RacunEF rac = db.Racuni.SingleOrDefault(x => x.Id == id);
            if (rac == null) return false;
            if (rac.RezervacijeDvorane != null)
            {
                for (int i = 0; i < rac.RezervacijeDvorane.Count; i++)
                {
                    db.RezervacijeDvorane.Remove(rac.RezervacijeDvorane.ElementAt(i));
                }
            }
            if (rac.RezervacijeSob != null)
            {
                for (int i = 0; i < rac.RezervacijeSob.Count; i++)
                {
                    db.RezervacijeSob.Remove(rac.RezervacijeSob.ElementAt(i));
                }
            }
            if (rac.RezervacijeParkirisca != null)
            {
                for (int i = 0; i < rac.RezervacijeParkirisca.Count; i++)
                {
                    db.RezervacijaParkirisca.Remove(rac.RezervacijeParkirisca.ElementAt(i));
                }
            }
            db.Racuni.Remove(rac);
            db.SaveChanges();
            return true;
        }

        public List<Racun> List()
        {
                List<RacunEF> racuni_ef = db.Racuni.ToList();
                List<Racun> racuni = (racuni_ef != null) ? Mapper.Map<List<RacunEF>, List<Racun>>(racuni_ef) : null;
                return racuni;
        }

        public List<Racun> readNeplacaniRacuniStranke(int idStranka)
        {
            List<RacunEF> racuni_ef = db.Racuni.Include("Stranka").Include("RezervacijeSob").Include("RezervacijeDvorane").Include("RezervacijeParkirisca").Where(q => q.Stranka.Id == idStranka).Where(x => x.Placano == false).ToList();
            List<Racun> racuni = (racuni_ef != null) ? Mapper.Map<List<RacunEF>, List<Racun>>(racuni_ef) : null;
            return racuni;
        }
    }
}
