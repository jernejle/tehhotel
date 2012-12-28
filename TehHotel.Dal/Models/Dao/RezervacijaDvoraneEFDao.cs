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
    public class RezervacijaDvoraneEFDao : IDao<RezervacijaDvorane>
    {

        public RezervacijaDvoraneEFDao()
        {
            Mapper.CreateMap<RezervacijaDvoraneEF, RezervacijaDvorane>();
            Mapper.CreateMap<RezervacijaDvorane, RezervacijaDvoraneEF>();

            Mapper.CreateMap<DvoranaEF, Dvorana>();
            Mapper.CreateMap<Dvorana, DvoranaEF>();

            Mapper.CreateMap<StrankaEF, Stranka>();
            Mapper.CreateMap<Stranka, StrankaEF>();

            Mapper.CreateMap<IdentifikacijaEF, Identifikacija>();
            Mapper.CreateMap<Identifikacija, IdentifikacijaEF>();
        }


        public bool Create(RezervacijaDvorane entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                if (entity != null)
                {
                    RezervacijaDvoraneEF rdef = Mapper.Map<RezervacijaDvorane, RezervacijaDvoraneEF>(entity);
                    db.RezervacijeDvorane.Add(rdef);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public RezervacijaDvorane Read(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                db.Configuration.LazyLoadingEnabled = true;
                RezervacijaDvoraneEF rdef = db.RezervacijeDvorane.Include("Stranka.Identifikacija").SingleOrDefault(x => x.Id == id);
                RezervacijaDvorane rd = (rdef != null) ? Mapper.Map<RezervacijaDvoraneEF, RezervacijaDvorane>(rdef) : null;
                return rd;
            }
        }

        public bool Update(RezervacijaDvorane entity)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                RezervacijaDvoraneEF rdef = Mapper.Map<RezervacijaDvorane, RezervacijaDvoraneEF>(entity);
                db.RezervacijeDvorane.Attach(rdef);
                db.Entry(rdef).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                RezervacijaDvoraneEF rdef = db.RezervacijeDvorane.SingleOrDefault(x => x.Id == id);

                if (rdef != null)
                {
                    db.RezervacijeDvorane.Remove(rdef);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<RezervacijaDvorane> List()
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                List<RezervacijaDvoraneEF> rez = db.RezervacijeDvorane.ToList();
                List<RezervacijaDvorane> rezerv_dv = (rez != null) ? Mapper.Map<List<RezervacijaDvoraneEF>,List<RezervacijaDvorane>>(rez) : null;
                return rezerv_dv;
            }
        }

        public List<Dvorana> mozneRezervacijeDvorane(int hotelid, DateTime datumOd, DateTime datumDo) {
            using (TehHotelContext db = new TehHotelContext())
            {
                List<RezervacijaDvorane> rezervacije = this.rezervacijeDvorane(hotelid, datumOd, datumDo);
                List<Dvorana> dvorane = Mapper.Map<List<DvoranaEF>, List<Dvorana>>(db.Dvorane.Where(x => x.HotelId == hotelid).ToList());
                List<Dvorana> prazne = new List<Dvorana>();

                if (rezervacije == null)
                {
                    return dvorane;
                }


                bool rezervirana = false;

                foreach (Dvorana dvorana in dvorane)
                {
                    foreach (RezervacijaDvorane rd in rezervacije)
                    {
                        if (dvorana.Id == rd.Dvorana.Id)
                        {
                            rezervirana = true;
                            break;
                        }
                    }
                    if (!rezervirana)
                    {
                        prazne.Add(dvorana);
                    }
                    rezervirana = false;
                }
                return prazne;
            }
        }

        public List<RezervacijaDvorane> rezervacijeDvorane(int hotelid, DateTime datumOd, DateTime datumDo)
        {
            using (TehHotelContext db = new TehHotelContext())
            {
                var query = from x in db.RezervacijeDvorane
                            where x.Dvorana.HotelId == hotelid &&
                            ((x.DatumOd < datumOd && x.DatumDo > datumDo) ||
                            (x.DatumOd >= datumOd && x.DatumDo <= datumDo) ||
                            (x.DatumOd >= datumOd && x.DatumOd <= datumDo) ||
                            (x.DatumDo <= datumDo && x.DatumDo >= datumOd))
                            select x;

                List<RezervacijaDvorane> list = new List<RezervacijaDvorane>();
                if (query.Count() != 0)
                {
                    foreach (var item in query.ToList())
                    {
                        list.Add(Mapper.Map<RezervacijaDvoraneEF, RezervacijaDvorane>(item));
                    }
                }
                return list;
            }
        }
    }
}
