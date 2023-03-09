using System;
using System.Collections.Generic;
using System.Linq;
using InsuranceHolders.Infra.Context;
using InsuranceHolders.Domain.Models;
using InsuranceHolders.Domain.Interfaces;

namespace InsuranceHolders.Infra.Repositories
{
    public class HolderQueriesRepository : IHolderQueriesRepository
    {
        private readonly DatabaseContext _db;

        public HolderQueriesRepository(DatabaseContext db)
        {
            _db = db;
        }

        public List<Holder> GetAllHolders()
        {
            var holders = _db.Holders;
            return holders.ToList();
        }

        public Holder GetHolderById(int holderId)
        {
            try
            {
                var holder = _db.Holders.Where(h => h.Id == holderId).
                First();

                return holder;
            }
            catch
            {
                throw new Exception("Holder not found.");
            }
        }
    }
}