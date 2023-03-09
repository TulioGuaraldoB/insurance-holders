using InsuranceHolders.Domain.Models;

namespace InsuranceHolders.Domain.Interfaces
{
    public interface IHolderCommands
    {
        void CreateHolder(Holder holder);
    }
}