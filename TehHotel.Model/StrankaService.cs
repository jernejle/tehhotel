using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TehHotel.Contracts.Service;
using TehHotel.Contracts.Data;
using TehHotel.Dal.Models.Dao;

namespace TehHotel.Model
{
    class StrankaService : IStrankaService
    {
        private StrankaEFDao dao = new StrankaEFDao();

        public bool CreateStranka(Stranka s)
        {
            return dao.Create(s);
        }

        public Stranka ReadStranka(int id)
        {
            return dao.Read(id);
        }

        public bool UpdateStranka(Stranka s)
        {
            return dao.Update(s);
        }

        public bool DeleteStranka(int id)
        {
            return dao.Delete(id);
        }

        public List<Stranka> ListStranka()
        {
            return dao.List();
        }

        public int CreateStrankaReturnId(Stranka s)
        {
            return dao.CreateStrankaId(s);
        }

        public Stranka IsciStranka(String IdentifikacijaTip, String IdentifikacijaVrednost)
        {
            return dao.ReadStrankaByIdentifikacija(IdentifikacijaTip, IdentifikacijaVrednost);
        }
    }
}
