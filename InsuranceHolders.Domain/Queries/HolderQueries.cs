using System.Collections.Generic;
using InsuranceHolders.Domain.Models;
using InsuranceHolders.Domain.Interfaces;

namespace InsuranceHolders.Domain.Queries
{
    public class HolderQueries : IHolderQueries
    {
        private readonly IHolderQueriesRepository _repository;

        public HolderQueries(IHolderQueriesRepository repository)
        {
            _repository = repository;
        }

        public List<Holder> GetAllHolders()
        {
            return _repository.GetAllHolders();
        }

        public Holder GetHolderById(int holderId)
        {
            return _repository.GetHolderById(holderId);
        }
    }
}