using Xunit;
using Moq;
using InsuranceHolders.Domain.Models;
using InsuranceHolders.Domain.Commands;
using InsuranceHolders.Domain.Interfaces;
using System;

namespace InsuranceHolders.Test.Domain.Commands
{
    public class HolderCommandsTest
    {
        [Fact]
        public void Should_Return_Success_On_CreateHolderCommand()
        {
            // Arrange
            var mockHolderCommandRepository = new Mock<IHolderCommandsRepository>();
            var data = new Holder
            {
                Name = "asdfasdgerghqfohgoiuret",
                DocumentCode = 346143,
            };

            // Act
            var holderCommand = new HolderCommands(mockHolderCommandRepository.Object);

            // Assert
            try
            {
                holderCommand.CreateHolder(data);
                return;
            }
            catch (Exception ex)
            {
                Assert.True(false, $"{(ex ?? ex.InnerException).Message}");
            }
        }
    }
}
