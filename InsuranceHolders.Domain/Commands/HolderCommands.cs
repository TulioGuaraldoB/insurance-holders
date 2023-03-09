using InsuranceHolders.Domain.Interfaces;
using InsuranceHolders.Domain.Models;

namespace InsuranceHolders.Domain.Commands
{
    public class HolderCommands : IHolderCommands
    {
        private readonly IHolderCommandsRepository _repository;

        public HolderCommands(IHolderCommandsRepository repository)
        {
            _repository = repository;
        }

        public void CreateHolder(Holder holder)
        {
            _repository.CreateHolder(holder);
        }
    }
}