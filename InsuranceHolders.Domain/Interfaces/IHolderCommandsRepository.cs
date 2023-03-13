using System.Threading.Tasks;
using InsuranceHolders.Domain.Models;

namespace InsuranceHolders.Domain.Interfaces
{
    public interface IHolderCommandsRepository
    {
        Task CreateHolder(Holder holder);
    }
}