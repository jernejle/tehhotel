using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TehHotel.Contracts.Data;

namespace TehHotel.Contracts.Service
{
    [ServiceContract(Name = "StrankaService", Namespace = "http//www.tehhotel.com/")]
    public interface IStrankaService
    {
        [OperationContract]
        bool CreateStranka(Stranka s);

        [OperationContract]
        Stranka ReadStranka(int id);

        [OperationContract]
        bool UpdateStranka(Stranka s);

        [OperationContract]
        bool DeleteStranka(int id);

        [OperationContract]
        List<Stranka> ListStranka();
    }
}
