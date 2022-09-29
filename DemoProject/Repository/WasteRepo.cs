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

        public IEnumerable<Waste> GetWastebyprodidenergy(int prodid)
        {
            return _dbContext.Wastes.Where(i => i.Cons_Id == prodid && i.Energy>0);
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
                existingWaste.Status = waste.Status;
            }
            _dbContext.SaveChanges();
            return waste;
        }

        public IEnumerable<Waste> Getorderedbyenergy(int prodid)
        {
            var pq= _dbContext.Wastes.Where(i => i.Prod_Id == prodid);

            var eq = (from waste in pq
                      orderby waste.Energy descending
                      select waste).Take(5);
            return eq;
        }

        public IEnumerable<Waste> Getorderedbyenergyc(int consid)
        {
            var pq = _dbContext.Wastes.Where(i => i.Cons_Id == consid);

            var eq = (from waste in pq
                      orderby waste.Energy descending
                      select waste).Take(5);
            return eq;
        }

        public IEnumerable<Waste> Getorderedbyquantity(int prodid)
        {
            var pq = _dbContext.Wastes.Where(i => i.Prod_Id == prodid);

            var eq = from waste in pq
                      orderby waste.Quantity descending
                      select waste;
            return eq;
        }

        public IEnumerable<Waste> Getorderedbyquantityc(int consid)
        {
            var pq = _dbContext.Wastes.Where(i => i.Cons_Id == consid);

            var eq = from waste in pq
                      orderby waste.Quantity descending
                      select waste;
            return eq;
        }

        public IEnumerable<Waste> Getlastwastebyprod(int prodid)
        {
            var pq = _dbContext.Wastes.Where(i => i.Prod_Id == prodid);

            var eq = (from waste in pq
                     orderby waste.Waste_Id descending
                     select waste).Take(7);
            return eq;
        }

        public IEnumerable<Waste> Getlastwastebycons(int consid)
        {
            var pq = _dbContext.Wastes.Where(i => i.Cons_Id == consid);

            var eq = (from waste in pq
                      orderby waste.Waste_Id descending
                      select waste).Take(7);
            return eq;
        }
    }
}
  
