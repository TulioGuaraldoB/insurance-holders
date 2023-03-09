using InsuranceHolders.Domain.Models;

namespace InsuranceHolders.Domain.Interfaces
{
    public interface IHolderCommandsRepository
    {
        void CreateHolder(Holder holder);
    }
}