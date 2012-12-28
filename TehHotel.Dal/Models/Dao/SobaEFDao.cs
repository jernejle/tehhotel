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
    public class SobaEFDao : IDao<Soba>
    {
        public SobaEFDao()
        {
            Mapper.CreateMap<SobaEF, Soba>();
            Mapper.CreateMap<Soba, SobaEF>();
        }

        public bool Create(Soba entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    SobaEF ef = Mapper.Map<Soba, SobaEF>(entity);
                    db.Sobe.Add(ef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Soba Read(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                SobaEF ef = db.Sobe.Find(id);
                if (ef != null)
                {
                    return Mapper.Map<SobaEF, Soba>(ef);
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Update(Soba entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    SobaEF ef = Mapper.Map<Soba, SobaEF>(entity);
                    db.Sobe.Attach(ef);
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
                SobaEF ef = db.Sobe.Find(id);
                if (ef != null)
                {
                    db.Sobe.Remove(ef);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Soba> List()
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                List<Soba> list = new List<Soba>();
                foreach (var item in db.Sobe.ToList())
                {
                    list.Add(Mapper.Map<SobaEF, Soba>(item));
                }
                return list;
            }
        }

        public List<Soba> List(int idHotel, FilterOptionsSoba fos)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                var query = from x in db.Sobe
                            where x.HotelId == idHotel
                            select x;

                if (fos.Balkon != null)
                    query = query.Where(a => a.Balkon == fos.Balkon);
                if (fos.Hladilnik != null)
                    query = query.Where(a => a.Hladilnik == fos.Hladilnik);
                if (fos.StPostelj != null)
                    query = query.Where(a => a.StPostelj == fos.StPostelj);
                if (fos.Internet != null)
                    query = query.Where(a => a.Internet == fos.Internet);
                if (fos.Nadstropje != null)
                    query = query.Where(a => a.Nadstropje == fos.Nadstropje);
                if (fos.Televizija != null)
                    query = query.Where(a => a.Televizija == fos.Televizija);
                if (fos.Zvezdice != null)
                    query = query.Where(a => a.Hotel.Zvezdice == fos.Zvezdice);

                List<Soba> list = new List<Soba>();
                foreach (var item in query.ToList())
                {
                    list.Add(Mapper.Map<SobaEF, Soba>(item));
                }
                return list;
            }
        }
    }
}
