using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service
{
    [ServiceContract/*(CallbackContract = typeof(ICallback))*/]
    public interface ILandService
    {
        [OperationContract/*(IsOneWay = true)*/]
        void AddLandLot
            (
                LandLotDTO landLotDTO,
                ExploitationTypeDTO exploitationTypeDTO,
                LandCategoryDTO landCategoryDTO,
                LocationDTO locationDTO,
                MonetaryValuationDTO monetaryValuationDTO,
                OwnershipTypeDTO ownershipTypeDTO,
                PurposeDTO purposeDTO,
                SoilDTO soilDTO,
                StateRegistrationInfoDTO stateRegistrationInfoDTO,
                ICollection<PhysicalIndividualDTO> physicalIndividualDTOs,
                JuridicalIndividualDTO juridicalIndividualDTO

            );

    }

    //public interface ICallback
    //{
    //}
}
