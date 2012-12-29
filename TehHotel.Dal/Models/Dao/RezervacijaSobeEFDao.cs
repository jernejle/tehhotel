using System.Data.Objects.SqlClient;
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
    public class RezervacijaSobeEFDao : IDao<RezervacijaSobe>
    {

        public RezervacijaSobeEFDao()
        {
            Mapper.CreateMap<RezervacijaSobeEF, RezervacijaSobe>();
            Mapper.CreateMap<RezervacijaSobe, RezervacijaSobeEF>();

            Mapper.CreateMap<HotelEF, Hotel>();
            Mapper.CreateMap<Hotel, HotelEF>();

            Mapper.CreateMap<StrankaEF, Stranka>();
            Mapper.CreateMap<Stranka, StrankaEF>();

            Mapper.CreateMap<SobaEF, Soba>();
            Mapper.CreateMap<Soba, SobaEF>();

            Mapper.CreateMap<NaslovEF, Naslov>();
            Mapper.CreateMap<Naslov, NaslovEF>();
        }

        public bool Create(RezervacijaSobe entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    RezervacijaSobeEF rsef = Mapper.Map<RezervacijaSobe, RezervacijaSobeEF>(entity);
                    rsef.Hotel = null;
                    rsef.Stranka = null;
                    rsef.Soba = null;
                    db.RezervacijeSob.Add(rsef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public RezervacijaSobe Read(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                var query = from x in db.RezervacijeSob.Include("Hotel").Include("Stranka").Include("Soba")
                            where x.Id == id
                            select x;
                if (query.Count() != 0)
                {
                    return Mapper.Map<RezervacijaSobeEF, RezervacijaSobe>(query.First());
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Update(RezervacijaSobe entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    RezervacijaSobeEF hef = Mapper.Map<RezervacijaSobe, RezervacijaSobeEF>(entity);
                    db.RezervacijeSob.Attach(hef);
                    db.Entry(hef).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                var query = from x in db.RezervacijeSob
                            where x.Id == id
                            select x;
                if (query.Count() != 0)
                {
                    RezervacijaSobeEF rsef = query.First();
                    db.RezervacijeSob.Remove(rsef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public List<RezervacijaSobe> List()
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                var query = from x in db.RezervacijeSob.Include("Hotel").Include("Stranka").Include("Soba")
                            select x;
                List<RezervacijaSobe> list = new List<RezervacijaSobe>();
                if (query.Count() != 0)
                {
                    foreach (var item in query.ToList())
                    {
                        list.Add(Mapper.Map<RezervacijaSobeEF, RezervacijaSobe>(item));
                    }
                }
                return list;
            }
        }

        public List<RezervacijaSobe> List(int idHotel, DateTime datumOd, DateTime datumDo, FilterOptionsSoba fos)
        {

            using (TehHotelContext db = new TehHotelContext())
            {
                var query = from x in db.RezervacijeSob.Include("Soba").Include("Hotel").Include("Stranka")
                            where x.HotelId == idHotel &&
                            ((x.DatumOd < datumOd && x.DatumDo > datumDo) ||
                            (x.DatumOd >= datumOd && x.DatumDo <= datumDo) ||
                            (x.DatumOd >= datumOd && x.DatumOd <= datumDo)||
                            (x.DatumDo <= datumDo && x.DatumDo >= datumOd))
                            select x;
                if (fos.Balkon != null)
                    query = query.Where(a => a.Soba.Balkon == fos.Balkon);
                if (fos.Hladilnik != null)
                    query = query.Where(a => a.Soba.Hladilnik == fos.Hladilnik);
                if (fos.StPostelj != null)
                    query = query.Where(a => a.Soba.StPostelj == fos.StPostelj);
                if (fos.Internet != null)
                    query = query.Where(a => a.Soba.Internet == fos.Internet);
                if (fos.Nadstropje != null)
                    query = query.Where(a => a.Soba.Nadstropje == fos.Nadstropje);
                if (fos.Televizija != null)
                    query = query.Where(a => a.Soba.Televizija == fos.Televizija);
                if (fos.Zvezdice != null)
                    query = query.Where(a => a.Hotel.Zvezdice == fos.Zvezdice);




                List<RezervacijaSobe> list = new List<RezervacijaSobe>();
                if (query.Count() != 0)
                {
                    foreach (var item in query.ToList())
                    {
                        list.Add(Mapper.Map<RezervacijaSobeEF, RezervacijaSobe>(item));
                    }
                }
                return list;
            }
        }

        public List<Soba> MozneRezervacijeSobe(int idHotel, DateTime datumOd, DateTime datumDo, FilterOptionsSoba fos)
        {
            SobaEFDao sobadao = new SobaEFDao();
            List<Soba> vseSobe = sobadao.List(idHotel, fos);
            List<RezervacijaSobe> rezsob = List(idHotel, datumOd, datumDo, fos);

            List<Soba> mozneRezervacije = new List<Soba>();
            foreach (Soba s in vseSobe)
            {
                bool zasedena = false;
                foreach (RezervacijaSobe rs in rezsob)
                {
                    if (s.Id == rs.Soba.Id){
                        zasedena = true;
                        break;
                    }
                }
                if (!zasedena)
                    mozneRezervacije.Add(s);
            }

            return mozneRezervacije;
        }
      
    }
}
