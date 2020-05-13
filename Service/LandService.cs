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

        public void AddLandLot
        (
            LandLotDTO landLotDTO,
            ExploitationTypeDTO exploitationTypeDTO,
            LocationDTO locationDTO,
            MonetaryValuationDTO monetaryValuationDTO,

            StateRegistrationInfoDTO stateRegistrationInfoDTO,
            ICollection<PhysicalIndividualDTO> physicalIndividualDTOs,
            JuridicalIndividualDTO juridicalIndividualDTO

        )
        {
            LandLot newLandLot = new LandLot()
            {
                CadastralNumber = landLotDTO.CadastralNumber,
                Area = landLotDTO.Area,
                LandCategoryId = landLotDTO.LandCategoryId,
                OwnershipTypeId = landLotDTO.OwnershipTypeId,
                PurposeId = landLotDTO.PurposeId,
                SoilId = landLotDTO.SoilId
            };



            newLandLot.LocationId = dal.AddLocations
                (new Location()
                {
                    District = locationDTO.District,
                    Region = locationDTO.Region,
                    Settlement = locationDTO.Settlement,
                    Street = locationDTO.Street
                }
                );




            newLandLot.MonetaryValuationId = dal.AddMonetaryValuation(new MonetaryValuation()
            {
                Value = monetaryValuationDTO.Value,
                Kf = monetaryValuationDTO.Kf,
                Km = monetaryValuationDTO.Km,
            });

            newLandLot.StateRegistrationInfoId = dal.AddStateRegistrationInfo(new StateRegistrationInfo()
            {
                RegistrationAgency = stateRegistrationInfoDTO.RegistrationAgency,
                TechnicalDocumentation = stateRegistrationInfoDTO.TechnicalDocumentation,
                DateTime = stateRegistrationInfoDTO.DateTime
            });

            if (dal.GetExploitationTypeByName(exploitationTypeDTO.Name) == null)
                dal.AddExploitationType(new ExploitationType() { Name = exploitationTypeDTO.Name });

            newLandLot.ExploitationTypeId = dal.GetExploitationTypeByName(exploitationTypeDTO.Name).Id;

            if (physicalIndividualDTOs != null)
            {
                Owner owner = new Owner();

                foreach (var item in physicalIndividualDTOs)
                {
                    if (item.Id == -1)
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

                newLandLot.OwnerId = dal.AddOwner(owner);
            }
            else
            {
                Owner owner = new Owner();

                if (null == dal.GetJuridicalIndividual(juridicalIndividualDTO.Name,
                    juridicalIndividualDTO.EDRPOUcode))
                    owner.JuridicalIndividualId = dal.AddJuridicalIndividual(new JuridicalIndividual()
                    {
                        EDRPOUcode = juridicalIndividualDTO.EDRPOUcode,
                        Name = juridicalIndividualDTO.Name
                    });
                else
                    owner.JuridicalIndividualId = dal.GetJuridicalIndividual
                       (juridicalIndividualDTO.Name,
                           juridicalIndividualDTO.EDRPOUcode).Id;


                newLandLot.OwnerId = dal.AddOwner(owner);
            }




            dal.AddLandLot(newLandLot);
        }


        public LandCategoryDTO[] GetLandCategories()
        {
            List<LandCategoryDTO> landCategoryDTOs = new List<LandCategoryDTO>();

            foreach (var item in dal.GetLandCategories())
            {
                landCategoryDTOs.Add(new LandCategoryDTO() { Id = item.Id, Name = item.Name });
            }
            return landCategoryDTOs.ToArray();
        }

        public SoilDTO[] GetSoils()
        {
            List<SoilDTO> soilDTOs = new List<SoilDTO>();

            foreach (var item in dal.GetSoils())
            {
                soilDTOs.Add(new SoilDTO() { Id = item.Id, Name = item.Name, AgroGroupCode = item.AgroGroupCode });
            }
            return soilDTOs.ToArray();
        }

        public PurposeDTO[] GetPurposes(string name)
        {
            List<PurposeDTO> purposeDTOs = new List<PurposeDTO>();

            IEnumerable<Purpose> purposes = null;

            if (name == "Землі сільськогосподарського призначення")
            {
                purposes = dal.GetPurposes().Where(p => p.Code.Substring(0, 2) == "01");
            }
            else if (name == "Землі житлової та громадської забудови")
            {
                purposes = dal.GetPurposes().Where(p => p.Code.Substring(0, 2) == "02" || p.Code.Substring(0, 2) == "03");
            }
            else if (name == "Землі природно-заповідного та іншого природоохоронного призначення")
            {
                purposes = dal.GetPurposes().Where(p => p.Code.Substring(0, 2) == "04" || p.Code.Substring(0, 2) == "05");
            }
            else if (name == "Землі оздоровчого призначення")
            {
                purposes = dal.GetPurposes().Where(p => p.Code.Substring(0, 2) == "06");
            }
            else if (name == "Землі рекреаційного призначення")
            {
                purposes = dal.GetPurposes().Where(p => p.Code.Substring(0, 2) == "07");
            }
            else if (name == "Землі історико-культурного призначення")
            {
                purposes = dal.GetPurposes().Where(p => p.Code.Substring(0, 2) == "08");
            }
            else if (name == "Землі лісогосподарського призначення")
            {
                purposes = dal.GetPurposes().Where(p => p.Code.Substring(0, 2) == "09");
            }
            else if (name == "Землі водного фонду")
            {
                purposes = dal.GetPurposes().Where(p => p.Code.Substring(0, 2) == "10");
            }
            else if (name == "Землі промисловості, транспорту, зв'язку, енергетики, оборони та іншого призначення")
            {
                purposes = dal.GetPurposes().Where(p =>
                   p.Code.Substring(0, 2) == "11"
                || p.Code.Substring(0, 2) == "12"
                || p.Code.Substring(0, 2) == "13"
                || p.Code.Substring(0, 2) == "14"
                || p.Code.Substring(0, 2) == "15");
            }
            else if (name == "Землі запасу, резервного фонду та загального користування")
            {
                purposes = dal.GetPurposes().Where(p =>
                       p.Code.Substring(0, 2) == "16"
                    || p.Code.Substring(0, 2) == "17"
                    || p.Code.Substring(0, 2) == "18"
                    || p.Code.Substring(0, 2) == "19");
            }


            if (purposes == null) return null;

            foreach (var item in purposes)
            {
                purposeDTOs.Add(new PurposeDTO() { Id = item.Id, Name = item.Name, Code = item.Code });
            }
            return purposeDTOs.ToArray();
        }

        public OwnershipTypeDTO[] GetOwnershipTypes()
        {
            List<OwnershipTypeDTO> ownershipTypeDTOs = new List<OwnershipTypeDTO>();

            foreach (var item in dal.GetOwnershipType())
            {
                ownershipTypeDTOs.Add(new OwnershipTypeDTO() { Id = item.Id, Name = item.Name });
            }
            return ownershipTypeDTOs.ToArray();
        }

        public LandLotDTO[] GetLandLotsbyLandCategory(string name)
        {
            List<LandLotDTO> landLotDTOs = new List<LandLotDTO>();

            foreach (var item in dal.GetLandLots())
            {
                if (item.LandCategory.Name == name)
                    landLotDTOs.Add
                            (new LandLotDTO()
                            {
                                Id = item.Id,
                                CadastralNumber = item.CadastralNumber,
                                Area = item.Area,
                                LandCategoryId = item.LandCategoryId,
                                OwnershipTypeId = item.OwnershipTypeId,
                                PurposeId = item.PurposeId,
                                SoilId = item.SoilId,
                                ExploitationTypeId = item.ExploitationTypeId,
                                LocationId = item.LocationId,
                                MonetaryValuationId = item.MonetaryValuationId,
                                StateRegistrationInfoId = item.StateRegistrationInfoId
                            });
            }

            if (landLotDTOs.Count == 0) return null;

            return landLotDTOs.ToArray();
        }

        public LandCategoryDTO GetLandCategoryById(int id)
        {
            LandCategory landCategory = dal.GetLandCategories().FirstOrDefault(l => l.Id == id);

            if (landCategory == null) return null;

            return new LandCategoryDTO() { Name = landCategory.Name, Id = landCategory.Id };
        }
    }


}
