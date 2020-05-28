﻿using DAL;
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
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
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
                owner.JuridicalIndividualId = null;

                foreach (var item in physicalIndividualDTOs)
                {
                    PhysicalIndividual physicalIndividual = dal.GetPhysicalIndividual(item.Name, item.Surname, item.MiddleName, item.DateOfBirth);

                    if ( null == physicalIndividual)
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
                        owner.PhysicalIndividuals.Add(physicalIndividual);
                }

                newLandLot.OwnerId = dal.AddOwner(owner);
            }
            else
            {
                Owner owner = new Owner();
                owner.PhysicalIndividuals = null;

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

        public LandLotDTO[] GetLandLotsbyPurpose(string purpose)
        {
            List<LandLotDTO> landLotDTOs = new List<LandLotDTO>();

            foreach (var item in dal.GetLandLots())
            {
                if (item.Purpose.Name == purpose || item.Purpose.Code == purpose || (item.Purpose.Code + " " + item.Purpose.Name) == purpose)
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

        public LandLotDTO[] GetLandLotsbyOwnershipType(string ownershipType)
        {
            List<LandLotDTO> landLotDTOs = new List<LandLotDTO>();

            foreach (var item in dal.GetLandLots())
            {
                if (item.OwnershipType.Name == ownershipType)
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

        public LandLotDTO[] GetLandLotsbySoil(string soil)
        {
            List<LandLotDTO> landLotDTOs = new List<LandLotDTO>();

            foreach (var item in dal.GetLandLots())
            {
                if (item.Soil.Name == soil || item.Soil.AgroGroupCode == soil || (item.Soil.AgroGroupCode + " " + item.Soil.Name) == soil)
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

        public LandLotDTO[] GetLandLotsbyOwner(string owner)
        {
            List<LandLotDTO> landLotDTOs = new List<LandLotDTO>();

            foreach (var item in dal.GetLandLots())
            {
                if (item.Owner.JuridicalIndividualId != null)
                {
                    if (item.Owner.JuridicalIndividual.Name == owner
                         || item.Owner.JuridicalIndividual.EDRPOUcode == owner
                         || (item.Owner.JuridicalIndividual.Name + " " + item.Owner.JuridicalIndividual.EDRPOUcode) == owner)
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
                else if (item.Owner.PhysicalIndividuals != null)
                {
                    foreach (var i in item.Owner.PhysicalIndividuals)
                    {
                        if (i.Surname + " " + i.Name + " " + i.MiddleName + " " + i.DateOfBirth.ToShortDateString() == owner)
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

                }
            }

            if (landLotDTOs.Count == 0) return null;

            return landLotDTOs.ToArray();
        }

        public LandLotDTO[] GetLandLotsbyCadastralNumber(string cadastralNumber)
        {
            List<LandLotDTO> landLotDTOs = new List<LandLotDTO>();

            foreach (var item in dal.GetLandLots())
            {
                if (item.CadastralNumber == cadastralNumber)
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

        public PurposeDTO GetPurposeById(int id)
        {
            Purpose purpose = dal.GetPurposes().FirstOrDefault(l => l.Id == id);

            if (purpose == null) return null;

            return new PurposeDTO() { Name = purpose.Name, Id = purpose.Id, Code = purpose.Code };
        }

        public ExploitationTypeDTO GetExploitationTypeById(int id)
        {
            ExploitationType exploitationType = dal.GetExploitationTypeById(id);

            if (exploitationType == null) return null;

            return new ExploitationTypeDTO() { Name = exploitationType.Name, Id = exploitationType.Id };
        }

        public SoilDTO GetSoilById(int id)
        {
            Soil soil = dal.GetSoils().FirstOrDefault(l => l.Id == id);

            if (soil == null) return null;

            return new SoilDTO() { Name = soil.Name, Id = soil.Id, AgroGroupCode = soil.AgroGroupCode };
        }
        public MonetaryValuationDTO GetMonetaryValuationById(int id)
        {
            MonetaryValuation monetaryValuation = dal.GetMonetaryValuationById(id);

            if (monetaryValuation == null) return null;

            return new MonetaryValuationDTO() { Kf = monetaryValuation.Kf, Km = monetaryValuation.Km, Value = monetaryValuation.Value, Id = monetaryValuation.Id };
        }
        public StateRegistrationInfoDTO GetStateRegistrationInfoById(int id)
        {
            StateRegistrationInfo stateRegistrationInfo = dal.GetStateRegistrationInfoById(id);

            if (stateRegistrationInfo == null) return null;

            return new StateRegistrationInfoDTO()
            {
                RegistrationAgency = stateRegistrationInfo.RegistrationAgency,
                TechnicalDocumentation = stateRegistrationInfo.TechnicalDocumentation,
                DateTime = stateRegistrationInfo.DateTime
            };
        }

        public JuridicalIndividualDTO GetOwnerByIdJ(int landlotid)
        {
            JuridicalIndividual juridical = dal.GetOwnerByIdJ(landlotid);

            if (juridical == null) return null;

            return new JuridicalIndividualDTO()
            {
                Id = juridical.Id,
                Name = juridical.Name,
                EDRPOUcode = juridical.EDRPOUcode
            };

        }

        public PhysicalIndividualDTO[] GetOwnerByIdP(int landlotid)
        {
            IEnumerable<PhysicalIndividual> physicalIndividuals = dal.GetOwnerByIdP(landlotid);

            if (physicalIndividuals == null) return null;
            if (physicalIndividuals.Count() == 0) return null;


            List<PhysicalIndividualDTO> physicalIndividualDTOs = new List<PhysicalIndividualDTO>();

            foreach (var item in physicalIndividuals)
            {
                physicalIndividualDTOs.Add(new PhysicalIndividualDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    MiddleName = item.MiddleName,
                    DateOfBirth = item.DateOfBirth
                }
                );
            }

            return physicalIndividualDTOs.ToArray();
        }

        public LocationDTO GetLocationById(int id)
        {
            Location location = dal.GetLocationById(id);

            if (location == null) return null;

            return new LocationDTO()
            {
                Id = location.Id,
                District = location.District,
                Region = location.Region,
                Settlement = location.Settlement,
                Street = location.Street
            };
        }

        public string GetOwnerType(int id)
        {
            LandLot landLot = dal.GetLandLots().FirstOrDefault(l => l.Id == id);

            if (landLot == null) return null;

            if (landLot.Owner.PhysicalIndividuals.Count > 0)
                return "PhysicalIndividuals";
            else if (landLot.Owner.JuridicalIndividualId != null)
                return "JuridicalIndividual";
            else
                return null;

        }

        public OwnershipTypeDTO GetOwnershipTypebyLandLotId(int id)
        {
            LandLot landLot = dal.GetLandLots().FirstOrDefault(l => l.Id == id);

            if (landLot == null) return null;

            return new OwnershipTypeDTO()
            {
                Id = landLot.OwnershipType.Id,
                Name = landLot.OwnershipType.Name
            };
        }

        public void EditLandLot
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

            LandLot landLot = dal.GetLandLots().FirstOrDefault(l => l.Id == landLotDTO.Id);

            if (landLot == null) return;

            landLot.CadastralNumber = landLotDTO.CadastralNumber;
            landLot.Area = landLotDTO.Area;
            landLot.LandCategoryId = landLotDTO.LandCategoryId;
            landLot.OwnershipTypeId = landLotDTO.OwnershipTypeId;
            landLot.PurposeId = landLotDTO.PurposeId;
            landLot.SoilId = landLotDTO.SoilId;

            landLot.Location.District = locationDTO.District;
            landLot.Location.Region = locationDTO.Region;
            landLot.Location.Settlement = locationDTO.Settlement;
            landLot.Location.Street = locationDTO.Street;

            landLot.MonetaryValuation.Value = monetaryValuationDTO.Value;
            landLot.MonetaryValuation.Kf = monetaryValuationDTO.Kf;
            landLot.MonetaryValuation.Km = monetaryValuationDTO.Km;



            landLot.StateRegistrationInfo.RegistrationAgency = stateRegistrationInfoDTO.RegistrationAgency;
            landLot.StateRegistrationInfo.TechnicalDocumentation = stateRegistrationInfoDTO.TechnicalDocumentation;
            landLot.StateRegistrationInfo.DateTime = stateRegistrationInfoDTO.DateTime;


            if (dal.GetExploitationTypeByName(exploitationTypeDTO.Name) == null)
                dal.AddExploitationType(new ExploitationType() { Name = exploitationTypeDTO.Name });

            landLot.ExploitationTypeId = dal.GetExploitationTypeByName(exploitationTypeDTO.Name).Id;

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
                owner.LandLotId = landLot.Id;
                landLot.OwnerId = dal.AddOwner(owner);
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

                owner.LandLotId = landLot.Id;
                landLot.OwnerId = dal.AddOwner(owner);
            }




            dal.SaveChanges();
        }
    }


}
