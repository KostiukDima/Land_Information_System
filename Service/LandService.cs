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
            dal.Test();
        }

        public void AddLandLot
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

        )
        {
            LandLot newLandLot = new LandLot()
            {
                CadastralNumber = landLotDTO.CadastralNumber,
                Area = landLotDTO.Area,
                LandCategoryId = landCategoryDTO.Id,
                OwnershipTypeId = ownershipTypeDTO.Id,
                PurposeId = purposeDTO.Id,
                SoilId = soilDTO.Id
            };

            newLandLot.Location = new Location()
            {
                District = locationDTO.District,
                Region = locationDTO.Region,
                Settlement = locationDTO.Settlement,
                Street = locationDTO.Street
            };

            newLandLot.MonetaryValuation = new MonetaryValuation()
            {
                Value = monetaryValuationDTO.Value,
                Kf = monetaryValuationDTO.Kf,
                Km = monetaryValuationDTO.Km,
            };

            newLandLot.StateRegistrationInfo = new StateRegistrationInfo()
            {
                RegistrationAgency = stateRegistrationInfoDTO.RegistrationAgency,
                TechnicalDocumentation= stateRegistrationInfoDTO.TechnicalDocumentation,
                DateTime = stateRegistrationInfoDTO.DateTime
            };

            if (dal.GetExploitationTypeByName(exploitationTypeDTO.Name) == null)
                dal.AddExploitationType(new ExploitationType() { Name = exploitationTypeDTO.Name });

            newLandLot.ExploitationTypeId = dal.GetExploitationTypeByName(exploitationTypeDTO.Name).Id;

            if (physicalIndividualDTOs != null)
            {
                Owner owner = new Owner();

                foreach (var item in physicalIndividualDTOs)
                {
                    if(item.Id==-1)
                    owner.PhysicalIndividuals.Add
                        (new PhysicalIndividual()
                            {
                                Name = item.Name,
                                Surname = item.Surname,
                                MiddleName = item.MiddleName,
                                DateOfBirth = item.DateOfBirth
                            }
                        );
                    else
                        owner.PhysicalIndividuals.Add
                        (new PhysicalIndividual()
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Surname = item.Surname,
                                MiddleName = item.MiddleName,
                                DateOfBirth = item.DateOfBirth
                            }
                        );



                }
                   
                newLandLot.Owner = owner;
            }
            else
            {
                if (juridicalIndividualDTO.Id == -1)
                    newLandLot.Owner = new Owner()
                    {
                        JuridicalIndividual = new JuridicalIndividual()
                        {
                            EDRPOUcode = juridicalIndividualDTO.EDRPOUcode,
                            Name = juridicalIndividualDTO.Name
                        }
                    };
                else
                    newLandLot.Owner = new Owner() { JuridicalIndividualId = juridicalIndividualDTO.Id };
            }




            dal.AddLandLot(newLandLot);
        }
    }
}
