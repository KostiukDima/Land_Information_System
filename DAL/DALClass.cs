using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALClass
    {
        LandSystemDBModel context;

        public DALClass()
        {
            context = new LandSystemDBModel(); 
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void AddLandLot(LandLot landLot)
        {
            landLot.Location = context.Locations.FirstOrDefault(l => l.Id == landLot.LocationId);
            //landLot.Owner = context.Owners.FirstOrDefault(l => l.Id == landLot.OwnerId);
            var existing = context.LandLots.FirstOrDefault(ll => ll.CadastralNumber == landLot.CadastralNumber);

            if (existing != null) return;

            context.LandLots.Add(landLot);
            context.SaveChanges();
        }
        
        

        public void AddExploitationType(ExploitationType exploitationType)
        {
            var existing = context.ExploitationTypes.FirstOrDefault(e => e.Name == exploitationType.Name);

            if (existing != null) return;

            context.ExploitationTypes.Add(exploitationType);
            context.SaveChanges();
        }
        public ExploitationType GetExploitationTypeByName(string exploitationTypeName)
        {
            var existing = context.ExploitationTypes.FirstOrDefault(e => e.Name == exploitationTypeName);

            if (existing == null) return null;
            else return existing;          
            
        }
        
        public int AddPhysicalIndividual(PhysicalIndividual physicalIndividual)
        {
            PhysicalIndividual pi = physicalIndividual;
            context.PhysicalIndividuals.Add(pi);
            context.SaveChanges();

            return pi.Id;
        }

        public int AddMonetaryValuation(MonetaryValuation monetaryValuation)
        {
            MonetaryValuation m = monetaryValuation;
            context.MonetaryValuations.Add(m);
            context.SaveChanges();

            return m.Id;
        } 
        public int AddStateRegistrationInfo(StateRegistrationInfo  stateRegistrationInfo)
        {
            StateRegistrationInfo s = stateRegistrationInfo;
            context.StateRegistrationInfos.Add(s);
            context.SaveChanges();

            return s.Id;
        }

        public int AddLocations(Location location)
        {
            Location l = location;
            context.Locations.Add(l);
            context.SaveChanges();

            return l.Id;
        }

        public Location GetLocationById(int id)
        {
            return context.Locations.FirstOrDefault(l => l.Id == id);
        }
        public MonetaryValuation GetMonetaryValuationById(int id)
        {
            return context.MonetaryValuations.FirstOrDefault(l => l.Id == id);
        }
        public StateRegistrationInfo GetStateRegistrationInfoById(int id)
        {
            return context.StateRegistrationInfos.FirstOrDefault(l => l.Id == id);
        }

        public ExploitationType GetExploitationTypeById(int id)
        {
            return context.ExploitationTypes.FirstOrDefault(l => l.Id == id);
        }

        public JuridicalIndividual GetOwnerByIdJ(int id)
        {
            int idp = context.LandLots.FirstOrDefault(l => l.Id == id).OwnerId;
            return context.Owners.FirstOrDefault(l => l.Id == idp).JuridicalIndividual;
        }

        public IEnumerable<PhysicalIndividual> GetOwnerByIdP(int id)
        {
            int idp = context.LandLots.FirstOrDefault(l => l.Id == id).OwnerId;
            if (context.Owners.FirstOrDefault(l => l.Id == idp).PhysicalIndividuals == null) return null; 
                return context.Owners.FirstOrDefault(l => l.Id == idp).PhysicalIndividuals.ToList();
        }

        public IEnumerable<LandCategory> GetLandCategories()
        {
            return context.LandCategories.ToList();
        }
        
        public IEnumerable<LandLot> GetLandLots()
        {
            return context.LandLots.ToList();
        }

        public IEnumerable<OwnershipType> GetOwnershipType()
        {
            return context.OwnershipTypes.ToList();
        }

        public IEnumerable<Soil> GetSoils()
        {
            return context.Soils.ToList();
        }
               
        public IEnumerable<Purpose> GetPurposes()
        {
            return context.Purposes.ToList();
        }

        public int AddJuridicalIndividual(JuridicalIndividual juridicalIndividual)
        {
            var existing = context.JuridicalIndividuals.FirstOrDefault
                (j => j.Name == juridicalIndividual.Name &&
                j.EDRPOUcode == juridicalIndividual.EDRPOUcode);

            if (existing != null) return 0;

            context.JuridicalIndividuals.Add(juridicalIndividual);
            context.SaveChanges();

            return juridicalIndividual.Id;
        }

        public int AddOwner(Owner owner)
        {          
            context.Owners.Add(owner);
            context.SaveChanges();

            return owner.Id;
        }
        public JuridicalIndividual GetJuridicalIndividual(string name, string EDRPOUcode)
        {
            var existing = context.JuridicalIndividuals.FirstOrDefault(j => j.Name == name && j.EDRPOUcode == EDRPOUcode);

            if (existing == null) return null;
            else return existing;

        }               

        public PhysicalIndividual GetPhysicalIndividual(string name, string surname, string middleName, DateTime dateOfBirth)
        {
            var existing = context.PhysicalIndividuals.FirstOrDefault
                (p => p.Name == name 
                && p.Surname == surname
                && p.MiddleName == middleName
                && DbFunctions.TruncateTime(p.DateOfBirth) == dateOfBirth.Date);

            if (existing == null) return null;
            else return existing;

        }
    }
}
