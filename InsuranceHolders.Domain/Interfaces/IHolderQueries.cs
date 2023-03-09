using System.Collections.Generic;
using InsuranceHolders.Domain.Models;

namespace InsuranceHolders.Domain.Interfaces
{
    public interface IHolderQueries
    {
        List<Holder> GetAllHolders();
        Holder GetHolderById(int holderId);
    }
}