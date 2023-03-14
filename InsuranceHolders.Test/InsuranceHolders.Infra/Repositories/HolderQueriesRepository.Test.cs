using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using InsuranceHolders.Infra.Context;
using InsuranceHolders.Domain.Models;
using InsuranceHolders.Infra.Repositories;

namespace InsuranceHolders.Test.Infra.Repositories
{
    public class HolderQueriesRepositoryTest
    {
        [Fact]
        public void Should_Return_Success_On_GetAllHoldersRepository()
        {
            // Arrange
            var mockContextOptions = new DbContextOptionsBuilder<DatabaseContext>();
            var mockContext = new Mock<DatabaseContext>(mockContextOptions.Options);
            var mockSet = new Mock<DbSet<Holder>>();
            var data = new List<Holder> { new Holder
            {
                Id = 1,
                Name = "asdfasdf",
                DocumentCode = 612,
             } }.AsQueryable();

            mockSet.As<IQueryable<Holder>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Holder>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Holder>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Holder>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockContext.Setup(m => m.Holders).Returns(mockSet.Object);

            // Act
            var holderQueriesRepository = new HolderQueriesRepository(mockContext.Object);
            var holders = holderQueriesRepository.GetAllHolders();

            // Assert
            Assert.NotNull(holders);
        }

        [Theory]
        [InlineData(12)]
        public void Should_Return_Success_On_GetHolderByIdRepository(int id)
        {
            // Assert
            var mockContextOptions = new DbContextOptionsBuilder<DatabaseContext>();
            var mockContext = new Mock<DatabaseContext>(mockContextOptions.Options);
            var mockSet = new Mock<DbSet<Holder>>();
            var data = new List<Holder>
            { new Holder{

                Id = 12,
                Name = "adfasdfgjhq",
                DocumentCode = 3214,
            }}.AsQueryable();

            mockSet.As<IQueryable<Holder>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Holder>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Holder>>().Setup(m => m.Provider).Returns(data.Provider);
            mockContext.Setup(m => m.Holders).Returns(mockSet.Object);

            // Act
            var holderQueriesRepository = new HolderQueriesRepository(mockContext.Object);
            var holder = holderQueriesRepository.GetHolderById(id);

            // Assert
            Assert.NotNull(holder);
        }
    }
}