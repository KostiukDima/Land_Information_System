using DAL.Models;
using System;
using System.Collections.Generic;
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

        public void AddLandLot(LandLot landLot)
        {
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

         public void Test()
        {
            context.ExploitationTypes.Add(new ExploitationType() { Name = "sdfnsjdf" }); 
        }

        public void AddJuridicalIndividual(JuridicalIndividual juridicalIndividual)
        {
            var existing = context.JuridicalIndividuals.FirstOrDefault(j => j.Name == juridicalIndividual.Name || j.EDRPOUcode == juridicalIndividual.EDRPOUcode);

            if (existing != null) return;

            context.JuridicalIndividuals.Add(juridicalIndividual);
            context.SaveChanges();
        }
        public JuridicalIndividual GetJuridicalIndividual(string name, string EDRPOUcode)
        {
            var existing = context.JuridicalIndividuals.FirstOrDefault(j => j.Name == name || j.EDRPOUcode == EDRPOUcode);

            if (existing == null) return null;
            else return existing;

        }
    }
}
