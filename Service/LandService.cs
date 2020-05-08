using DAL;
using DAL.Models;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class LandService : ILandService
    {
        private static DALClass dal = new DALClass();
        
        public LandService()
        {
                
        }

        public void AddLandLot(LandLotDTO landLotDTO)
        {
            LandLot newLandLot = new LandLot()
            {
                CadastralNumber = landLotDTO.CadastralNumber,
                Area = landLotDTO.Area
            };
            
            
            dal.AddLandLot(newLandLot);
        }
    }
}
