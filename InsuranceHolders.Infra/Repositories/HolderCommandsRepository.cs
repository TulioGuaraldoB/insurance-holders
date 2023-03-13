using System;
using InsuranceHolders.Infra.Context;
using InsuranceHolders.Domain.Models;
using InsuranceHolders.Domain.Interfaces;
using System.Threading.Tasks;

namespace InsuranceHolders.Infra.Repositories
{
    public class HolderCommandsRepository : IHolderCommandsRepository
    {
        private readonly DatabaseContext _db;

        public HolderCommandsRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task CreateHolder(Holder holder)
        {
            try
            {
                _db.Holders.Add(holder);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create holder. {(ex ?? ex.InnerException).Message}");
            }
        }
    }
}