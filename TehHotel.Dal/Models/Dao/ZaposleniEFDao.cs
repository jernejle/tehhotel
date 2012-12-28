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
    public class ZaposleniEFDao : IDao<Zaposleni>
    {
        public ZaposleniEFDao()
        {
            Mapper.CreateMap<ZaposleniEF, Zaposleni>();
            Mapper.CreateMap<Zaposleni, ZaposleniEF>();
            Mapper.CreateMap<NaslovEF, Naslov>();
            Mapper.CreateMap<Naslov, NaslovEF>();
            Mapper.CreateMap<IdentifikacijaEF, Identifikacija>();
            Mapper.CreateMap<Identifikacija, IdentifikacijaEF>();
            Mapper.CreateMap<HotelEF, Hotel>();
            Mapper.CreateMap<Hotel, HotelEF>();
        }

        public bool Create(Zaposleni entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    ZaposleniEF ef = Mapper.Map<Zaposleni, ZaposleniEF>(entity);
                    db.Osebje.Add(ef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Zaposleni Read(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                ZaposleniEF ef = db.Osebje.Find(id);
                if (ef != null)
                {
                    return Mapper.Map<ZaposleniEF, Zaposleni>(ef);
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Update(Zaposleni entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    ZaposleniEF ef = Mapper.Map<Zaposleni, ZaposleniEF>(entity);
                    db.Osebje.Attach(ef);
                    db.Entry(ef).State = EntityState.Modified;
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
                ZaposleniEF ef = db.Osebje.Find(id);
                if (ef != null)
                {
                    db.Osebje.Remove(ef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Zaposleni> List()
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                List<Zaposleni> list = new List<Zaposleni>();
                foreach (var item in db.Osebje.ToList())
                {
                    list.Add(Mapper.Map<ZaposleniEF, Zaposleni>(item));
                }
                return list;
            }
        }
    }
}
