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
    public class ParkirisceEFDao : IDao<Parkirisce>
    {
        public ParkirisceEFDao()
        {
            Mapper.CreateMap<ParkirisceEF, Parkirisce>();
            Mapper.CreateMap<Parkirisce, ParkirisceEF>();
        }

        public bool Create(Parkirisce entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    ParkirisceEF pef = Mapper.Map<Parkirisce, ParkirisceEF>(entity);
                    db.Parkirisca.Add(pef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Parkirisce Read(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                ParkirisceEF ef = db.Parkirisca.Find(id);
                if (ef != null)
                {
                    return Mapper.Map<ParkirisceEF, Parkirisce>(ef);
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Update(Parkirisce entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    ParkirisceEF ef = Mapper.Map<Parkirisce, ParkirisceEF>(entity);
                    db.Parkirisca.Attach(ef);
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
                ParkirisceEF ef = db.Parkirisca.Find(id);
                if (ef != null)
                {
                    db.Parkirisca.Remove(ef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Parkirisce> List()
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                List<Parkirisce> list = new List<Parkirisce>();
                foreach (var item in db.Parkirisca.ToList())
                {
                    list.Add(Mapper.Map<ParkirisceEF, Parkirisce>(item));
                }
                return list;
            }
        }
    }
}
