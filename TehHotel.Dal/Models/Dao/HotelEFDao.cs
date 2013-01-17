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
    public class HotelEFDao : IDao<Hotel>
    {
        public HotelEFDao()
        {
            Mapper.CreateMap<HotelEF, Hotel>();
            Mapper.CreateMap<Hotel, HotelEF>();
            Mapper.CreateMap<NaslovEF, Naslov>();
            Mapper.CreateMap<Naslov, NaslovEF>();
            Mapper.CreateMap<ZaposleniEF, Zaposleni>();
            Mapper.CreateMap<Zaposleni, ZaposleniEF>();
            Mapper.CreateMap<ParkirisceEF, Parkirisce>();
            Mapper.CreateMap<Parkirisce, ParkirisceEF>();
            Mapper.CreateMap<SobaEF, Soba>();
            Mapper.CreateMap<Soba, SobaEF>();
        }

        public bool Create(Hotel entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    HotelEF hef = Mapper.Map<Hotel, HotelEF>(entity);
                    hef.Osebje = null;
                    hef.Parkirisca = null;
                    hef.Sobe = null;
                    hef.Dvorane = null;
                    db.Hoteli.Add(hef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Hotel Read(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                var query = from x in db.Hoteli
                                .Include("Parkirisca")
                                .Include("Naslov")
                                .Include("Sobe")
                                .Include("Dvorane")
                                .Include("Osebje")
                            where x.Id == id
                            select x;
                if (query.Count() != 0)
                {
                    return Mapper.Map<HotelEF, Hotel>(query.First());
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Update(Hotel entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    HotelEF hef = Mapper.Map<Hotel, HotelEF>(entity);
                    db.Hoteli.Attach(hef);
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
                var query = from x in db.Hoteli
                                .Include("Parkirisca")
                                .Include("Naslov")
                                .Include("Sobe")
                                .Include("Dvorane")
                                .Include("Osebje")
                            where x.Id == id
                            select x;
                if (query.Count() != 0)
                {
                    HotelEF hef = query.First();
                    List<SobaEF> sobe = hef.Sobe.ToList();
                    foreach (SobaEF ef in sobe)
                    {
                        db.Sobe.Remove(ef);
                    }
                    List<ParkirisceEF> parkirisca = hef.Parkirisca.ToList();
                    foreach (ParkirisceEF ef in parkirisca)
                    {
                        db.Parkirisca.Remove(ef);
                    }
                    List<DvoranaEF> dvorane = hef.Dvorane.ToList();
                    foreach (DvoranaEF ef in dvorane)
                    {
                        db.Dvorane.Remove(ef);
                    }
                    db.Hoteli.Remove(hef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Hotel> List()
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                List<HotelEF> query = db.Hoteli
                                .Include("Parkirisca")
                                .Include("Naslov")
                                .Include("Sobe")
                                .Include("Dvorane")
                                .Include("Osebje")
                                .ToList();
                List<Hotel> list = new List<Hotel>();
                if (query.Count() != 0)
                {
                    foreach (var item in query)
                    {
                        list.Add(Mapper.Map<HotelEF, Hotel>(item));
                    }
                }
                return list;
            }
        }
    }
}
