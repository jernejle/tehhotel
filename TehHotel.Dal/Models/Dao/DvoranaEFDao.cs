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
    public class DvoranaEFDao : IDao<Dvorana>
    {
        public DvoranaEFDao()
        {
            Mapper.CreateMap<DvoranaEF, Dvorana>();
            Mapper.CreateMap<Dvorana, DvoranaEF>();
        }

        public bool Create(Dvorana entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    DvoranaEF def = Mapper.Map<Dvorana, DvoranaEF>(entity);
                    db.Dvorane.Add(def);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Dvorana Read(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                DvoranaEF ef = db.Dvorane.Find(id);
                if (ef != null)
                {
                    return Mapper.Map<DvoranaEF, Dvorana>(ef);
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Update(Dvorana entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    DvoranaEF def = Mapper.Map<Dvorana, DvoranaEF>(entity);
                    db.Dvorane.Attach(def);
                    db.Entry(def).State = EntityState.Modified;
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
                DvoranaEF ef = db.Dvorane.Find(id);
                if (ef != null)
                {
                    db.Dvorane.Remove(ef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public List<Dvorana> List()
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                List<Dvorana> list = new List<Dvorana>();
                foreach (var item in db.Dvorane.ToList())
                {
                    list.Add(Mapper.Map<DvoranaEF, Dvorana>(item));
                }
                return list;
            }
        }
    }
}
