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
    class StrankaRESTService : IStrankaRESTService
    {
        private StrankaEFDao dao = new StrankaEFDao();

        public bool CreateStranka(Stranka s)
        {
            return dao.Create(s);
        }

        public Stranka ReadStranka(string id)
        {
            int idInt = Convert.ToInt32(id);
            return dao.Read(idInt);
        }

        public bool UpdateStranka(string id, Stranka s)
        {
            int idInt = Convert.ToInt32(id);
            s.Id=idInt;
            return dao.Update(s);
        }

        public bool DeleteStranka(string id)
        {
            int idInt = Convert.ToInt32(id);
            return dao.Delete(idInt);
        }

        public List<Stranka> ListStranka()
        {
            return dao.List();
        }
    }
}
