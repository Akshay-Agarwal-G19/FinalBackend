using DemoProject.Data;
using DemoProject.Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Repository
{
    public class WasteRepo
    {
        public DemoProjectDbContext _dbContext;
        public WasteRepo(DemoProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Waste> GetWaste()
        {
            return _dbContext.Wastes;
        }

        public IEnumerable<Waste> GetWastebyid(int Id)
        {
            return _dbContext.Wastes.Where(i => i.Waste_Id == Id);
        }

        public IEnumerable<Waste> GetWastebyprodid(int prodid)
        {
            return _dbContext.Wastes.Where(i => i.Prod_Id == prodid);
        }

        public IEnumerable<Waste> GetWastebyreqconsid(int reqconsid)
        {
            return _dbContext.Wastes.Where(i => i.Request_Cons_Id == reqconsid);
        }

        public IEnumerable<Waste> GetWastebyconsid(int consid)
        {
            return _dbContext.Wastes.Where(i => i.Cons_Id == consid);
        }

        public int GetProdIdbyid(Waste waste)
        {
            Waste findwaste = _dbContext.Wastes.Find(waste.Waste_Id);
            return findwaste.Prod_Id;
        }


        public Waste Addwaste(Waste waste)
        {
            _dbContext.Wastes.Add(waste);
            _dbContext.SaveChanges();
            return waste;
        }

        public Waste Updatestatus(Waste waste)
        {
            Waste existingWaste = _dbContext.Wastes.Find(waste.Waste_Id);
            if (existingWaste != null)
            {
                existingWaste.Status = waste.Status;
            }
            _dbContext.SaveChanges();
            return waste;
        }
        public Waste Updateenergy(Waste waste)
        {
            Waste existingWaste = _dbContext.Wastes.Find(waste.Waste_Id);
            if (existingWaste != null)
            {
                existingWaste.Energy = waste.Energy;        
            }
            _dbContext.SaveChanges();
            return waste;
        }

        public Waste Updateconsid(Waste waste)
        {
            Waste existingWaste = _dbContext.Wastes.Find(waste.Waste_Id);
            if (existingWaste != null)
            {
                existingWaste.Cons_Id = waste.Cons_Id;
            }
            _dbContext.SaveChanges();
            return waste;
        }
    }
}
  
