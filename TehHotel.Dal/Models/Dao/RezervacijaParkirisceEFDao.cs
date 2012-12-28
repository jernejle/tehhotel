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
    public class RezervacijaParkirisceEFDao : IDao<RezervacijaParkirisca>
    {

        public RezervacijaParkirisceEFDao()
        {
            Mapper.CreateMap<RezervacijaParkiriscaEF, RezervacijaParkirisca>();
            Mapper.CreateMap<RezervacijaParkirisca, RezervacijaParkiriscaEF>();

            Mapper.CreateMap<StrankaEF, Stranka>();
            Mapper.CreateMap<Stranka, StrankaEF>();

            Mapper.CreateMap<IdentifikacijaEF, Identifikacija>();
            Mapper.CreateMap<Identifikacija, IdentifikacijaEF>();

            Mapper.CreateMap<ParkirisceEF, Parkirisce>();
            Mapper.CreateMap<Parkirisce, ParkirisceEF>();
        }

        public bool Create(RezervacijaParkirisca entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    RezervacijaParkiriscaEF rpef = Mapper.Map<RezervacijaParkirisca, RezervacijaParkiriscaEF>(entity);
                    db.RezervacijaParkirisca.Add(rpef);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public RezervacijaParkirisca Read(int id)
        {
                using (TehHotelContext db = new TehHotelContext())
                {
                    db.Configuration.LazyLoadingEnabled = true;
                    RezervacijaParkiriscaEF rpef = db.RezervacijaParkirisca.Include("Stranka.Identifikacija").SingleOrDefault(x => x.Id == id);
                    RezervacijaParkirisca rp = (rpef != null) ? Mapper.Map<RezervacijaParkiriscaEF, RezervacijaParkirisca>(rpef) : null;
                    return rp;
                }
        }

        public bool Update(RezervacijaParkirisca entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                RezervacijaParkiriscaEF rpef = Mapper.Map<RezervacijaParkirisca, RezervacijaParkiriscaEF>(entity);
                db.RezervacijaParkirisca.Attach(rpef);
                db.Entry(rpef).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                RezervacijaParkiriscaEF rpef = db.RezervacijaParkirisca.SingleOrDefault(x => x.Id == id);

                if (rpef != null)
                {
                    db.RezervacijaParkirisca.Remove(rpef);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<RezervacijaParkirisca> List()
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                List<RezervacijaParkiriscaEF> rez = db.RezervacijaParkirisca.ToList();
                List<RezervacijaParkirisca> rez_park = (rez != null) ? Mapper.Map<List<RezervacijaParkiriscaEF>,List<RezervacijaParkirisca>>(rez) : null;
                return rez_park;
            }
        }

        public List<RezervacijaParkirisca> rezervacijeParkirisca(int hotelid, DateTime datumOd, DateTime datumDo)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                var query = from x in db.RezervacijaParkirisca
                            where x.Parkirisce.HotelId == hotelid &&
                            ((x.DatumOd < datumOd && x.DatumDo > datumDo) ||
                            (x.DatumOd >= datumOd && x.DatumDo <= datumDo) ||
                            (x.DatumOd >= datumOd && x.DatumOd <= datumDo) ||
                            (x.DatumDo <= datumDo && x.DatumDo >= datumOd))
                            select x;

                List<RezervacijaParkirisca> list = new List<RezervacijaParkirisca>();
                if (query.Count() != 0)
                {
                    foreach (var item in query.ToList())
                    {
                        list.Add(Mapper.Map<RezervacijaParkiriscaEF, RezervacijaParkirisca>(item));
                    }
                }
                return list;
            }
        }

        public List<Parkirisce> mozneRezervacijeParkirisca(int hotelid, DateTime datumOd, DateTime datumDo)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                List<RezervacijaParkirisca> rezervacije = this.rezervacijeParkirisca(hotelid, datumOd, datumDo);
                List<Parkirisce> parkirisca = Mapper.Map<List<ParkirisceEF>, List<Parkirisce>>(db.Parkirisca.Where(x => x.HotelId == hotelid).ToList());
                List<Parkirisce> prazne = new List<Parkirisce>();

                if (rezervacije == null)
                {
                    return parkirisca;
                }


                bool rezervirana = false;

                foreach (Parkirisce parkirisce in parkirisca)
                {
                    foreach (RezervacijaParkirisca rp in rezervacije)
                    {
                        if (parkirisce.Id == rp.Parkirisce.Id)
                        {
                            rezervirana = true;
                            break;
                        }
                    }
                    if (!rezervirana)
                    {
                        prazne.Add(parkirisce);
                    }
                    rezervirana = false;
                }
                return prazne;
            }
        }
    }
}
