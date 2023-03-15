using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateHolder(Holder holder)
        {
            try
            {
                _db.Holders.Add(holder);
                await _db.SaveChangesAsync();

                _db.Entry(holder).State = EntityState.Added;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to create holder. {(ex ?? ex.InnerException).Message}");
            }
        }
    }
}