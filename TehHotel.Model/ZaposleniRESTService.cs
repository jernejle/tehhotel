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
    class ZaposleniRESTService : IZaposleniRESTService
    {
        private ZaposleniEFDao dao = new ZaposleniEFDao();

        public bool CreateZaposleni(Zaposleni z)
        {
            return dao.Create(z);
        }

        public Zaposleni ReadZaposleni(string id)
        {
            int idInt = Convert.ToInt32(id);
            return dao.Read(idInt);
        }

        public bool UpdateZaposleni(string id, Zaposleni z)
        {
            int idInt = Convert.ToInt32(id);
            z.Id = idInt;
            return dao.Update(z);
        }

        public bool DeleteZaposleni(string id)
        {
            int idInt = Convert.ToInt32(id);
            return dao.Delete(idInt);
        }

        public List<Zaposleni> ListZaposleni()
        {
            return dao.List();
        }
    }
}
