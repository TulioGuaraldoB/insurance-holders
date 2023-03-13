using System.Collections.Generic;
using Xunit;
using Moq;
using InsuranceHolders.Domain.Models;
using InsuranceHolders.Domain.Queries;
using InsuranceHolders.Domain.Interfaces;

namespace InsuranceHolders.Test.Domain.Queries
{
    public class HolderQueriesTest
    {
        [Fact]
        public void Should_Return_Success_On_GetAllHoldersQuery()
        {
            // Arrange
            var mockRepository = new Mock<IHolderQueriesRepository>();
            var data = new List<Holder> { new Holder
            {
                Id = 12,
                Name = "asdlfkksadfqwer",
                DocumentCode = 332,
            } };

            // Act
            mockRepository.Setup(q => q.GetAllHolders()).Returns(data);
            var holderQuery = new HolderQueries(mockRepository.Object);
            var holders = holderQuery.GetAllHolders();

            // Assert
            Assert.NotNull(holders);
        }

        [Theory]
        [InlineData(10)]
        public void Should_Return_success_On_GetHolderByIdQuery(int id)
        {
            // Arrange
            var mockHolderQueriesRepository = new Mock<IHolderQueriesRepository>();
            var data = new Holder
            {
                Id = 10,
                Name = "asdlfkksadfqwer",
                DocumentCode = 332,
            };

            // Act
            mockHolderQueriesRepository.Setup(q => q.GetHolderById(id)).Returns(data);
            var holderQuery = new HolderQueries(mockHolderQueriesRepository.Object);
            var holder = holderQuery.GetHolderById(id);

            // Assert
            Assert.NotNull(holder);
        }
    }
}