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
    public class StrankaEFDao : IDao<Stranka>
    {
        public StrankaEFDao()
        {
            Mapper.CreateMap<StrankaEF, Stranka>();
            Mapper.CreateMap<Stranka, StrankaEF>();

            Mapper.CreateMap<NaslovEF, Naslov>();
            Mapper.CreateMap<Naslov, NaslovEF>();

            Mapper.CreateMap<IdentifikacijaEF, Identifikacija>();
            Mapper.CreateMap<Identifikacija, IdentifikacijaEF>();
        }


        public bool Create(Stranka entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    StrankaEF sef = Mapper.Map<Stranka, StrankaEF>(entity);
                    db.Stranke.Add(sef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Stranka Read(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                var query = from x in db.Stranke.
                                Include("Identifikacija").
                                Include("Naslov")
                            where x.Id == id
                            select x;
                if (query.Count() != 0)
                {
                    return Mapper.Map<StrankaEF, Stranka>(query.First());
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Update(Stranka entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    StrankaEF sef = Mapper.Map<Stranka, StrankaEF>(entity);
                    db.Stranke.Attach(sef);
                    db.Entry(sef).State = EntityState.Modified;
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
                var query = from x in db.Stranke
                            where x.Id == id
                            select x;
                if (query.Count() != 0)
                {
                    StrankaEF sef = query.First();
                    db.Stranke.Remove(sef);

                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public List<Stranka> List()
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                var query = from x in db.Stranke.Include("Identifikacija").Include("Naslov")
                            select x;
                List<Stranka> list = new List<Stranka>();
                if (query.Count() != 0)
                {
                    foreach (var item in query.ToList())
                    {
                        list.Add(Mapper.Map<StrankaEF, Stranka>(item));
                    }
                }
                return list;
            }
        }
    }
}
