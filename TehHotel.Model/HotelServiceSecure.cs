using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TehHotel.Contracts.Data;
using TehHotel.Contracts.Service;
using TehHotel.Dal.Models.Dao;

namespace TehHotel.Model
{
    class HotelServiceSecure : IHotelService
    {
        HotelEFDao hdao;
        SobaEFDao sdao;
        DvoranaEFDao ddao;
        ParkirisceEFDao pdao;
        ZaposleniEFDao zdao;

        public HotelServiceSecure()
        {
            hdao = new HotelEFDao();
            sdao = new SobaEFDao();
            ddao = new DvoranaEFDao();
            pdao = new ParkirisceEFDao();
            zdao = new ZaposleniEFDao();
        }

        public bool CreateHotel(Hotel h)
        {
            return hdao.Create(h);
        }

        public Hotel ReadHotel(int id)
        {
            return hdao.Read(id);
        }

        public bool UpdateHotel(Hotel h)
        {
            return hdao.Update(h);
        }

        public bool DeleteHotel(int id)
        {
            return hdao.Delete(id);
        }

        public List<Hotel> ListHotel()
        {
            return hdao.List();
        }

        public List<Hotel> ListHotelByKraj(string kraj)
        {
            return hdao.List().Where(x => x.Naslov.Kraj == kraj).ToList();
        }

        public List<Hotel> ListHotelByDrzava(string drzava)
        {
            return hdao.List().Where(x => x.Naslov.Drzava == drzava).ToList();
        }

        public bool AddSoba(int hotelId, Soba s)
        {
            s.HotelId = hotelId;
            if (hdao.Read(hotelId) != null)
            {
                return sdao.Create(s);
            }
            else
            {
                return false;
            }
        }

        public bool RemoveSoba(int hotelId, int sobaId)
        {
            Soba s = sdao.Read(sobaId);
            if (s != null)
            {
                if (s.HotelId == hotelId)
                {
                    return sdao.Delete(sobaId);
                }
            }
            return false;
        }

        public bool AddDvorana(int hotelId, Dvorana d)
        {
            d.HotelId = hotelId;
            if (hdao.Read(hotelId) != null)
            {
                return ddao.Create(d);
            }
            else
            {
                return false;
            }
        }

        public bool RemoveDvorana(int hotelId, int dvoranaId)
        {
            Dvorana d = ddao.Read(dvoranaId);
            if (d != null)
            {
                if (d.HotelId == hotelId)
                {
                    return ddao.Delete(dvoranaId);
                }
            }
            return false;
        }

        public bool AddParkirisce(int hotelId, Parkirisce p)
        {
            p.HotelId = hotelId;
            if (hdao.Read(hotelId) != null)
            {
                return pdao.Create(p);
            }
            else
            {
                return false;
            }
        }

        public bool RemoveParkirisce(int hotelId, int parkirisceId)
        {
            Parkirisce p = pdao.Read(parkirisceId);
            if (p != null)
            {
                if (p.HotelId == hotelId)
                {
                    return pdao.Delete(parkirisceId);
                }
            }
            return false;
        }

        public bool CreateZaposleni(Zaposleni z)
        {
            if (z.HotelId != null)
            {
                Hotel h = hdao.Read((int)z.HotelId);
                if (h != null)
                {
                    return zdao.Create(z);
                }
            }
            else
            {
                return zdao.Create(z);
            }
            return false;
        }

        public Zaposleni ReadZaposleni(int id)
        {
            return zdao.Read(id);
        }

        public bool UpdateZaposleni(Zaposleni z)
        {
            if (z.HotelId != null)
            {
                Hotel h = hdao.Read((int)z.HotelId);
                if (h != null)
                {
                    return zdao.Update(z);
                }
            }
            else
            {
                return zdao.Update(z);
            }
            return false;
        }

        public bool DeleteZaposleni(int id)
        {
            return zdao.Delete(id);
        }

        public List<Zaposleni> ListZaposleni()
        {
            return zdao.List();
        }

        public List<Zaposleni> ListZaposleniByHotel(int hotelId)
        {
            return zdao.List().Where(x => x.HotelId == hotelId).ToList();
        }
    }
}
