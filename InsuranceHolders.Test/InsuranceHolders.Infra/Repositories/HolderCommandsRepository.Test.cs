using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using InsuranceHolders.Infra.Context;
using InsuranceHolders.Domain.Models;
using InsuranceHolders.Infra.Repositories;

namespace InsuranceHolders.Test.Infra.Repositories
{
    public class HolderCommandsRepositoryTest
    {
        [Fact]
        public async Task Should_Return_Success_On_CreateHolderRepository()
        {
            // Arrange
            var mockContextOptions = new DbContextOptionsBuilder<DatabaseContext>();
            var mockContext = new Mock<DatabaseContext>(mockContextOptions.Options);
            var mockSet = new Mock<DbSet<Holder>>();
            var holder = new Holder
            {
                Id = 21,
                Name = "asdfasfasdf",
                DocumentCode = 332,
            };

            mockContext.Setup(m => m.Holders).Returns(mockSet.Object);

            // Act
            var holderCommandsRepository = new HolderCommandsRepository(mockContext.Object);
            await holderCommandsRepository.CreateHolder(holder);

            // Assert
            mockSet.Verify(h => h.Add(It.Is<Holder>(m => m == holder)));
        }
    }
}