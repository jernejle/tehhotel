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
    public class NaslovEFDao : IDao<Naslov>
    {
        public NaslovEFDao()
        {
            Mapper.CreateMap<NaslovEF, Naslov>();
            Mapper.CreateMap<Naslov, NaslovEF>();
        }

        public bool Create(Naslov entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    NaslovEF ef = Mapper.Map<Naslov, NaslovEF>(entity);
                    db.Naslovi.Add(ef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Naslov Read(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                NaslovEF ef = db.Naslovi.Find(id);
                if (ef != null)
                {
                    return Mapper.Map<NaslovEF, Naslov>(ef);
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Update(Naslov entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    NaslovEF ef = Mapper.Map<Naslov, NaslovEF>(entity);
                    db.Naslovi.Attach(ef);
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
                NaslovEF ef = db.Naslovi.Find(id);
                if (ef != null)
                {
                    db.Naslovi.Remove(ef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Naslov> List()
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                List<Naslov> list = new List<Naslov>();
                foreach (var item in db.Naslovi.ToList())
                {
                    list.Add(Mapper.Map<NaslovEF, Naslov>(item));
                }
                return list;
            }
        }
    }
}
