﻿using Service.DTO;
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
                LocationDTO locationDTO,
                MonetaryValuationDTO monetaryValuationDTO,                
                StateRegistrationInfoDTO stateRegistrationInfoDTO,
                ICollection<PhysicalIndividualDTO> physicalIndividualDTOs,
                JuridicalIndividualDTO juridicalIndividualDTO

            );


        [OperationContract]
        PurposeDTO GetPurposeById(int id);
        [OperationContract]
        ExploitationTypeDTO GetExploitationTypeById(int id);
        [OperationContract]
        SoilDTO GetSoilById(int id);
        [OperationContract]
        MonetaryValuationDTO GetMonetaryValuationById(int id);
        [OperationContract]
        StateRegistrationInfoDTO GetStateRegistrationInfoById(int id);
        [OperationContract]
        JuridicalIndividualDTO GetOwnerByIdJ(int landlotid);
        [OperationContract]
        PhysicalIndividualDTO[] GetOwnerByIdP(int landlotid);
        [OperationContract]
        LocationDTO GetLocationById(int id);
        [OperationContract]
        LandCategoryDTO GetLandCategoryById(int id);
        [OperationContract]
        LandLotDTO[] GetLandLotsbyLandCategory(string name);
        [OperationContract]
        LandCategoryDTO[] GetLandCategories(); 
        
        [OperationContract]
        SoilDTO[] GetSoils();
        
        [OperationContract]
        OwnershipTypeDTO[] GetOwnershipTypes();
        
        [OperationContract]
        PurposeDTO[] GetPurposes(string name);

    }

    //public interface ICallback
    //{
    //}
}
