using System;
using InsuranceHolders.Infra.Context;
using InsuranceHolders.Domain.Models;
using InsuranceHolders.Domain.Interfaces;

namespace InsuranceHolders.Infra.Repositories
{
    public class HolderCommandsRepository : IHolderCommandsRepository
    {
        private readonly DatabaseContext _db;

        public HolderCommandsRepository(DatabaseContext db)
        {
            _db = db;
        }

        public void CreateHolder(Holder holder)
        {
            try
            {
                _db.Holders.Add(holder);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create holder. {(ex ?? ex.InnerException).Message}");
            }
        }
    }
}