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
    public class IdentifikacijaEFDao : IDao<Identifikacija>
    {
        public IdentifikacijaEFDao()
        {
            Mapper.CreateMap<IdentifikacijaEF, Identifikacija>();
            Mapper.CreateMap<Identifikacija, IdentifikacijaEF>();
        }

        public bool Create(Identifikacija entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    IdentifikacijaEF ief = Mapper.Map<Identifikacija, IdentifikacijaEF>(entity);
                    db.Identifikacije.Add(ief);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Identifikacija Read(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                IdentifikacijaEF ef = db.Identifikacije.Find(id);
                if (ef != null)
                {
                    return Mapper.Map<IdentifikacijaEF, Identifikacija>(ef);
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Update(Identifikacija entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    IdentifikacijaEF ef = Mapper.Map<Identifikacija, IdentifikacijaEF>(entity);
                    db.Identifikacije.Attach(ef);
                    db.Entry(entity).State = EntityState.Modified;
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
                IdentifikacijaEF ef = db.Identifikacije.Find(id);
                if (ef != null)
                {
                    db.Identifikacije.Remove(ef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Identifikacija> List()
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                List<Identifikacija> list = new List<Identifikacija>();
                foreach (var item in db.Identifikacije.ToList())
                {
                    list.Add(Mapper.Map<IdentifikacijaEF, Identifikacija>(item));
                }
                return list;
            }
        }
    }
}
