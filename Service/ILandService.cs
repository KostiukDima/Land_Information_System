using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface ILandService
    {
        [OperationContract(IsOneWay = true)]
        void AddLandLot(LandLotDTO landLotDTO);

    }

    public interface ICallback
    {
    }
}
